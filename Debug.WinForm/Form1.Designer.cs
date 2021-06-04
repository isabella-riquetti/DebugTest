
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Debug.WinForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3"});
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(132, 355);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseMove);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Item 4",
            "Item 5"});
            this.listBox2.Location = new System.Drawing.Point(169, 13);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(132, 355);
            this.listBox2.TabIndex = 1;
            this.listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            this.listBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseMove);
            this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private Point mDownPos;
        void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            mDownPos = e.Location;
        }
        void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            var senderObj = (ListBox)sender;
            if (e.Button != MouseButtons.Left) return;
            int index = senderObj.IndexFromPoint(e.Location);
            if (index < 0) return;
            if (Math.Abs(e.X - mDownPos.X) >= SystemInformation.DragSize.Width ||
                Math.Abs(e.Y - mDownPos.Y) >= SystemInformation.DragSize.Height)
                DoDragDrop(new DragObject(senderObj, senderObj.Items[index]), DragDropEffects.Move);
        }

        void listBox_DragEnter(object sender, DragEventArgs e)
        {
            var senderObj = (ListBox)sender;
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (obj != null && obj.source != senderObj) e.Effect = e.AllowedEffect;
        }
        void listBox_DragDrop(object sender, DragEventArgs e)
        {
            var senderObj = (ListBox)sender;
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            senderObj.Items.Add(obj.item);
            obj.source.Items.Remove(obj.item);
        }

        private class DragObject
        {
            public ListBox source;
            public object item;
            public DragObject(ListBox box, object data) { source = box; item = data; }
        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

