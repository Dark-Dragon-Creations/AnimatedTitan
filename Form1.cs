using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Processing;

namespace AnimatedTitan
{
    public partial class Form1 : Form
    {
        private Config? _config; // Make _config nullable
        private readonly string _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnimatedTitan", "config.json");

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
            PopulateFields();
        }

        private void LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(_configPath));
            }
            else
            {
                var defaultDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _config = new Config
                {
                    ImageFolder = Path.Combine(defaultDocumentsPath, "AnimatedTitan", "Input"),
                    OutputPath = Path.Combine(defaultDocumentsPath, "AnimatedTitan", "Output"),
                    Filename = "Animated.gif",
                    TotalDuration = 5000
                };
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            var configDir = Path.GetDirectoryName(_configPath);
            if (!string.IsNullOrEmpty(configDir) && !Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }

            if (_config != null)
            {
                _config.ImageFolder = txtImageFolder.Text;
                _config.OutputPath = txtOutputPath.Text;
                _config.Filename = txtFilename.Text;
                _config.TotalDuration = int.TryParse(txtTotalDuration.Text, out int duration) ? duration : 5000;
                File.WriteAllText(_configPath, JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
        }

        private void PopulateFields()
        {
            if (_config != null)
            {
                txtImageFolder.Text = _config.ImageFolder;
                txtOutputPath.Text = _config.OutputPath;
                txtFilename.Text = _config.Filename;
                txtTotalDuration.Text = _config.TotalDuration.ToString();
            }
        }

        private void UpdateStatus(string message)
        {
            txtMessages.Text = message + Environment.NewLine + txtMessages.Text;
        }

        private void btnFindImageFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(txtImageFolder.Text))
                {
                    dialog.SelectedPath = txtImageFolder.Text;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnFindOutputPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(txtOutputPath.Text))
                {
                    dialog.SelectedPath = txtOutputPath.Text;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnCreateGif_Click(object sender, EventArgs e)
        {
            if (_config == null)
            {
                UpdateStatus("Configuration is not loaded.");
                return;
            }

            _config.ImageFolder = txtImageFolder.Text;
            _config.OutputPath = txtOutputPath.Text;
            _config.Filename = txtFilename.Text;
            _config.TotalDuration = int.TryParse(txtTotalDuration.Text, out int duration) ? duration : 5000;

            // Check if the input image folder exists
            if (!Directory.Exists(_config.ImageFolder))
            {
                UpdateStatus($"Image folder '{_config.ImageFolder}' does not exist.");
                return;
            }

            // Ensure the output directory exists and the output path includes a file name
            var outputDir = _config.OutputPath;
            if (string.IsNullOrEmpty(outputDir) || string.IsNullOrEmpty(_config.Filename))
            {
                UpdateStatus("Output path must include a directory and a file name.");
                return;
            }
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
                UpdateStatus($"Created output directory '{outputDir}'.");
            }

            var fullOutputPath = Path.Combine(outputDir, _config.Filename);

            var images = Directory.GetFiles(_config.ImageFolder, "*.png")
                                  .OrderBy(f => f)
                                  .Select(f => SixLabors.ImageSharp.Image.Load(f))
                                  .ToList();

            if (!images.Any())
            {
                UpdateStatus($"No PNG images found in the folder '{_config.ImageFolder}'.");
                return;
            }

            UpdateStatus("Processing images...");

            // Calculate the duration for each frame
            var frameDuration = _config.TotalDuration / images.Count / 10; // Convert to hundredths of a second

            try
            {
                using (var outputStream = File.OpenWrite(fullOutputPath))
                {
                    var gifMetaData = images[0].Metadata.GetGifMetadata();
                    gifMetaData.RepeatCount = 0;

                    for (int i = 0; i < images.Count; i++)
                    {
                        var frameMetaData = images[i].Frames.RootFrame.Metadata.GetGifMetadata();
                        frameMetaData.FrameDelay = frameDuration;
                        UpdateStatus($"Processed frame {i + 1}/{images.Count}");
                    }

                    images[0].SaveAsGif(outputStream, new GifEncoder
                    {
                        ColorTableMode = GifColorTableMode.Global
                    });
                }

                UpdateStatus($"GIF saved to {fullOutputPath}");
            }
            catch (UnauthorizedAccessException ex)
            {
                UpdateStatus($"Access denied when trying to write to {fullOutputPath}: {ex.Message}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error when trying to write to {fullOutputPath}: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveConfig();
            base.OnFormClosing(e);
        }
    }

    public class Config
    {
        [JsonProperty("image_folder")]
        public string ImageFolder { get; set; } = string.Empty;

        [JsonProperty("output_path")]
        public string OutputPath { get; set; } = string.Empty;

        [JsonProperty("filename")]
        public string Filename { get; set; } = "Animated.gif";

        [JsonProperty("total_duration")]
        public int TotalDuration { get; set; } = 0;
    }
}
