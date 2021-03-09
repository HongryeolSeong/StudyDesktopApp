
namespace CheckBoxWinApp
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
            this.ChkApple = new System.Windows.Forms.CheckBox();
            this.ChkPear = new System.Windows.Forms.CheckBox();
            this.ChkStrawberry = new System.Windows.Forms.CheckBox();
            this.ChkBanana = new System.Windows.Forms.CheckBox();
            this.ChkOrange = new System.Windows.Forms.CheckBox();
            this.ChkWatermelon = new System.Windows.Forms.CheckBox();
            this.BtnResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "질문 : 좋아하는 과일을 모두 선택하세요.";
            // 
            // ChkApple
            // 
            this.ChkApple.AutoSize = true;
            this.ChkApple.Location = new System.Drawing.Point(14, 53);
            this.ChkApple.Name = "ChkApple";
            this.ChkApple.Size = new System.Drawing.Size(48, 16);
            this.ChkApple.TabIndex = 1;
            this.ChkApple.Text = "사과";
            this.ChkApple.UseVisualStyleBackColor = true;
            // 
            // ChkPear
            // 
            this.ChkPear.AutoSize = true;
            this.ChkPear.Location = new System.Drawing.Point(14, 91);
            this.ChkPear.Name = "ChkPear";
            this.ChkPear.Size = new System.Drawing.Size(36, 16);
            this.ChkPear.TabIndex = 2;
            this.ChkPear.Text = "배";
            this.ChkPear.UseVisualStyleBackColor = true;
            // 
            // ChkStrawberry
            // 
            this.ChkStrawberry.AutoSize = true;
            this.ChkStrawberry.Location = new System.Drawing.Point(14, 129);
            this.ChkStrawberry.Name = "ChkStrawberry";
            this.ChkStrawberry.Size = new System.Drawing.Size(48, 16);
            this.ChkStrawberry.TabIndex = 3;
            this.ChkStrawberry.Text = "딸기";
            this.ChkStrawberry.UseVisualStyleBackColor = true;
            // 
            // ChkBanana
            // 
            this.ChkBanana.AutoSize = true;
            this.ChkBanana.Location = new System.Drawing.Point(14, 167);
            this.ChkBanana.Name = "ChkBanana";
            this.ChkBanana.Size = new System.Drawing.Size(48, 16);
            this.ChkBanana.TabIndex = 4;
            this.ChkBanana.Text = "바나";
            this.ChkBanana.UseVisualStyleBackColor = true;
            // 
            // ChkOrange
            // 
            this.ChkOrange.AutoSize = true;
            this.ChkOrange.Location = new System.Drawing.Point(14, 205);
            this.ChkOrange.Name = "ChkOrange";
            this.ChkOrange.Size = new System.Drawing.Size(60, 16);
            this.ChkOrange.TabIndex = 5;
            this.ChkOrange.Text = "오렌지";
            this.ChkOrange.UseVisualStyleBackColor = true;
            // 
            // ChkWatermelon
            // 
            this.ChkWatermelon.AutoSize = true;
            this.ChkWatermelon.Location = new System.Drawing.Point(14, 243);
            this.ChkWatermelon.Name = "ChkWatermelon";
            this.ChkWatermelon.Size = new System.Drawing.Size(48, 16);
            this.ChkWatermelon.TabIndex = 6;
            this.ChkWatermelon.Text = "수박";
            this.ChkWatermelon.UseVisualStyleBackColor = true;
            // 
            // BtnResult
            // 
            this.BtnResult.Location = new System.Drawing.Point(211, 253);
            this.BtnResult.Name = "BtnResult";
            this.BtnResult.Size = new System.Drawing.Size(79, 28);
            this.BtnResult.TabIndex = 7;
            this.BtnResult.Text = "결과";
            this.BtnResult.UseVisualStyleBackColor = true;
            this.BtnResult.Click += new System.EventHandler(this.BtnResult_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 293);
            this.Controls.Add(this.BtnResult);
            this.Controls.Add(this.ChkWatermelon);
            this.Controls.Add(this.ChkOrange);
            this.Controls.Add(this.ChkBanana);
            this.Controls.Add(this.ChkStrawberry);
            this.Controls.Add(this.ChkPear);
            this.Controls.Add(this.ChkApple);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Favorite Fruits App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkApple;
        private System.Windows.Forms.CheckBox ChkPear;
        private System.Windows.Forms.CheckBox ChkStrawberry;
        private System.Windows.Forms.CheckBox ChkBanana;
        private System.Windows.Forms.CheckBox ChkOrange;
        private System.Windows.Forms.CheckBox ChkWatermelon;
        private System.Windows.Forms.Button BtnResult;
    }
}

