﻿
namespace Restaurant
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.CboRestaurant = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemoe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "좋아하는 식당 리스트";
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.Location = new System.Drawing.Point(41, 214);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(117, 12);
            this.LblResult.TabIndex = 1;
            this.LblResult.Text = "이번주 모임장소는 : ";
            // 
            // CboRestaurant
            // 
            this.CboRestaurant.FormattingEnabled = true;
            this.CboRestaurant.Location = new System.Drawing.Point(43, 67);
            this.CboRestaurant.Name = "CboRestaurant";
            this.CboRestaurant.Size = new System.Drawing.Size(194, 20);
            this.CboRestaurant.TabIndex = 2;
            this.CboRestaurant.SelectedIndexChanged += new System.EventHandler(this.CboRestaurant_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(276, 59);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 34);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "추가";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemoe
            // 
            this.BtnRemoe.Location = new System.Drawing.Point(276, 99);
            this.BtnRemoe.Name = "BtnRemoe";
            this.BtnRemoe.Size = new System.Drawing.Size(90, 34);
            this.BtnRemoe.TabIndex = 4;
            this.BtnRemoe.Text = "삭제";
            this.BtnRemoe.UseVisualStyleBackColor = true;
            this.BtnRemoe.Click += new System.EventHandler(this.BtnRemoe_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 276);
            this.Controls.Add(this.BtnRemoe);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CboRestaurant);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "좋아하는 레스토랑";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.ComboBox CboRestaurant;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemoe;
    }
}
