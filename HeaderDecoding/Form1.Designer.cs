namespace HeaderDecoding
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_load = new System.Windows.Forms.Button();
            this.decode_headers = new System.Windows.Forms.Button();
            this.file_info = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.PictureBox();
            this.event_log_box = new System.Windows.Forms.TextBox();
            this.event_log = new System.Windows.Forms.Label();
            this.load_fft = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.ffft = new System.Windows.Forms.PictureBox();
            this.bfft = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ffft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfft)).BeginInit();
            this.SuspendLayout();
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(26, 12);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(148, 41);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load File";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // decode_headers
            // 
            this.decode_headers.Location = new System.Drawing.Point(26, 68);
            this.decode_headers.Name = "decode_headers";
            this.decode_headers.Size = new System.Drawing.Size(148, 41);
            this.decode_headers.TabIndex = 1;
            this.decode_headers.Text = "Decode header";
            this.decode_headers.UseVisualStyleBackColor = true;
            this.decode_headers.Click += new System.EventHandler(this.decode_headers_Click);
            // 
            // file_info
            // 
            this.file_info.AutoSize = true;
            this.file_info.Location = new System.Drawing.Point(218, 9);
            this.file_info.Name = "file_info";
            this.file_info.Size = new System.Drawing.Size(119, 17);
            this.file_info.TabIndex = 2;
            this.file_info.Text = "No file is selected";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(221, 31);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(200, 155);
            this.preview.TabIndex = 3;
            this.preview.TabStop = false;
            // 
            // event_log_box
            // 
            this.event_log_box.Location = new System.Drawing.Point(453, 31);
            this.event_log_box.Multiline = true;
            this.event_log_box.Name = "event_log_box";
            this.event_log_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.event_log_box.Size = new System.Drawing.Size(258, 264);
            this.event_log_box.TabIndex = 4;
            // 
            // event_log
            // 
            this.event_log.AutoSize = true;
            this.event_log.Location = new System.Drawing.Point(450, 9);
            this.event_log.Name = "event_log";
            this.event_log.Size = new System.Drawing.Size(67, 17);
            this.event_log.TabIndex = 5;
            this.event_log.Text = "Event log";
            // 
            // load_fft
            // 
            this.load_fft.Location = new System.Drawing.Point(26, 126);
            this.load_fft.Name = "load_fft";
            this.load_fft.Size = new System.Drawing.Size(148, 41);
            this.load_fft.TabIndex = 6;
            this.load_fft.Text = "FFT";
            this.load_fft.UseVisualStyleBackColor = true;
            this.load_fft.Click += new System.EventHandler(this.load_fft_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(501, 301);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(156, 37);
            this.clear_button.TabIndex = 7;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // ffft
            // 
            this.ffft.Location = new System.Drawing.Point(26, 377);
            this.ffft.Name = "ffft";
            this.ffft.Size = new System.Drawing.Size(256, 256);
            this.ffft.TabIndex = 8;
            this.ffft.TabStop = false;
            // 
            // bfft
            // 
            this.bfft.Location = new System.Drawing.Point(328, 377);
            this.bfft.Name = "bfft";
            this.bfft.Size = new System.Drawing.Size(256, 256);
            this.bfft.TabIndex = 9;
            this.bfft.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "FFT Result";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Inverted FFT Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 655);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bfft);
            this.Controls.Add(this.ffft);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.load_fft);
            this.Controls.Add(this.event_log);
            this.Controls.Add(this.event_log_box);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.file_info);
            this.Controls.Add(this.decode_headers);
            this.Controls.Add(this.button_load);
            this.Name = "Form1";
            this.Text = "Header Decoding";
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ffft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button decode_headers;
        private System.Windows.Forms.Label file_info;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.TextBox event_log_box;
        private System.Windows.Forms.Label event_log;
        private System.Windows.Forms.Button load_fft;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.PictureBox ffft;
        private System.Windows.Forms.PictureBox bfft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

