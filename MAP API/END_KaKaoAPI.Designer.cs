
namespace TIS.ERP.POPUP
{
    partial class END_KaKaoAPI
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_search = new System.Windows.Forms.Button();
            this.tbox_query = new System.Windows.Forms.TextBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lbox_locale = new System.Windows.Forms.ListBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.wb_map = new System.Windows.Forms.WebBrowser();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBarManager
            // 
            this.TitleBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2});
            this.TitleBarManager.MaxItemId = 11;
            // 
            // bar_Title
            // 
            this.bar_Title.OptionsBar.AllowQuickCustomization = false;
            this.bar_Title.OptionsBar.DisableClose = true;
            this.bar_Title.OptionsBar.DisableCustomization = true;
            this.bar_Title.OptionsBar.DrawDragBorder = false;
            this.bar_Title.OptionsBar.UseWholeRow = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_search);
            this.panelControl1.Controls.Add(this.tbox_query);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 43);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(744, 63);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(443, 15);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(61, 22);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "검색";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbox_query
            // 
            this.tbox_query.Location = new System.Drawing.Point(197, 15);
            this.tbox_query.Name = "tbox_query";
            this.tbox_query.Size = new System.Drawing.Size(224, 22);
            this.tbox_query.TabIndex = 0;
            this.tbox_query.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbox_query_KeyUp);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lbox_locale);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(0, 106);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(329, 135, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(234, 502);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lbox_locale
            // 
            this.lbox_locale.FormattingEnabled = true;
            this.lbox_locale.HorizontalScrollbar = true;
            this.lbox_locale.ItemHeight = 14;
            this.lbox_locale.Location = new System.Drawing.Point(12, 12);
            this.lbox_locale.Name = "lbox_locale";
            this.lbox_locale.Size = new System.Drawing.Size(210, 466);
            this.lbox_locale.TabIndex = 4;
            this.lbox_locale.SelectedIndexChanged += new System.EventHandler(this.lbox_locale_SelectedIndexChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(234, 502);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lbox_locale;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(214, 482);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.wb_map);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(234, 106);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(510, 502);
            this.layoutControl2.TabIndex = 2;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // wb_map
            // 
            this.wb_map.Location = new System.Drawing.Point(12, 12);
            this.wb_map.MinimumSize = new System.Drawing.Size(20, 23);
            this.wb_map.Name = "wb_map";
            this.wb_map.Size = new System.Drawing.Size(486, 478);
            this.wb_map.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(510, 502);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.wb_map;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(490, 482);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // END_KaKaoAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "END_KaKaoAPI";
            this.Size = new System.Drawing.Size(744, 608);
            this.PopupActivate += new System.EventHandler(this.END_KaKaoAPI_PopupActivate);
            this.PopupSelected += new System.EventHandler(this.END_KaKaoAPI_PopupSelected);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.layoutControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tbox_query;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ListBox lbox_locale;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private System.Windows.Forms.WebBrowser wb_map;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}
