using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIS.Data;
using TIS.ERP;
using TIS.DataClient;
using TIS.Controls;
using TIS.ERP.COMMON;
using DevExpress.XtraEditors.Repository;


namespace TIS.ERP.POPUP
{
    public partial class PUELCOST_SAVE : TIS.Controls.BizCustomPopupBase
    {
        public BizPageBase parent = null;
        public string TRIP_NO = null;
        TIS.ERP.POPUP.START_KaKaoAPI popupSKaKao = null;
        TIS.Controls.BizPopupRepositoryConnector m_popupSKaKao = null;
        TIS.ERP.POPUP.END_KaKaoAPI popupEKaKao = null;
        TIS.Controls.BizPopupRepositoryConnector m_popupEKaKao = null;

        public bool popcheck = false;
        public bool checkReload
        {
            get
            {
                return popcheck;
            }
        }

        public PUELCOST_SAVE()
        {
            InitializeComponent();
        }

        private void PUELCOST_SAVE_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void PUELCOST_SAVE_PopupActivate(object sender, EventArgs e)
        {

            DataTable dtData = new DataTable();
            DataRow dRow = null;


            //배차 SELECT
            DbCommand dc1 = new DbCommand();
            dc1.CommandText = "up_erp_PUEL_COST_SELECT";
            dc1.Parameters.Add(new DbParameter("@TRIP_NO", TRIP_NO));

            DataSet _ds1 = parent.DbClient.GetDataSet(dc1);

            gridControl2.DataSource = _ds1.Tables[0];
            (gridControl2.DataSource as DataTable).AcceptChanges();
            

            //CallCommand(BizCommand.AddRow);

            DbCommand dc = new DbCommand();

            //왕복
            dtData = parent.DbClient.GetDataTableFromSP("up_erp_COMMON_CODE",
                new DbParameter("@CODEGROUP", "PS"),
                new DbParameter("@MCODE", "PSFCT01"));
            dRow = dtData.NewRow();
            dRow["CODE"] = DBNull.Value;
            dRow["NAME"] = DBNull.Value;
            dtData.Rows.InsertAt(dRow, 0);
            repositoryItemLookUpEdit4.DataSource = dtData;
            TIS.Controls.LookUpEdit.AdjustDropDownRows(repositoryItemLookUpEdit4, 15);

            ////유류
            dtData = parent.DbClient.GetDataTableFromSP("up_erp_COMMON_CODE",
                new DbParameter("@CODEGROUP", "PS"),
                new DbParameter("@MCODE", "PSFCT02"));
            dRow = dtData.NewRow();
            dRow["CODE"] = DBNull.Value;
            dRow["NAME"] = DBNull.Value;
            dtData.Rows.InsertAt(dRow, 0);
            repositoryItemLookUpEdit5.DataSource = dtData;
            TIS.Controls.LookUpEdit.AdjustDropDownRows(repositoryItemLookUpEdit5, 15);



            popupSKaKao = new POPUP.START_KaKaoAPI();
            popupSKaKao.AutoSetResultValue = false;
            m_popupSKaKao = new BizPopupRepositoryConnector(popupSKaKao, repositoryItemPopupContainerEdit1);
            m_popupSKaKao.SetPopupResultFields("Name", "Lng", "Lat");
            m_popupSKaKao.SetResultTargetFields("START_MAP", "START_LNG", "START_LAT");

            popupEKaKao = new POPUP.END_KaKaoAPI();
            popupEKaKao.AutoSetResultValue = false;
            m_popupEKaKao = new BizPopupRepositoryConnector(popupEKaKao, repositoryItemPopupContainerEdit2);
            m_popupEKaKao.SetPopupResultFields("Name", "Lng", "Lat");
            m_popupEKaKao.SetResultTargetFields("END_MAP", "END_LNG", "END_LAT");

            this.ParentForm.FormClosing += ParentForm_FormClosing;

        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView2.PostEditor();
            gridView2.UpdateCurrentRow();

             DataTable dt = gridControl2.DataSource as DataTable;

            
            try 
            {
                    if(dt.Columns["PUEL_COST"].ToString()!=null || dt.Columns["PUEL_COST"].ToString() == "0")
                     {
                       if (parent.ShowMessage("ERPE0464", new string[] { "행선지를 정확하게 등록 하였습니까?" },
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1).Equals(DialogResult.No))
                       {
                           e.Cancel = true;
                           return;
                       }

                       parent.DbClient.ExecSPTrn("up_erp_PUEL_COST_SAVE",
                       new DbParameter("@XML_DATA", DataUtil.DataTableToXml(dt, DataRowState.Added | DataRowState.Modified | DataRowState.Deleted | DataRowState.Unchanged)),
                       new DbParameter("@TRIP_NO", TRIP_NO)
                       );

                       DataRow dr = dt.NewRow();

                       int sum = 0;

                       sum = Convert.ToInt32(dt.Compute("Sum(PUEL_COST)", ""));

                       DataTable _dt = new DataTable();
                       _dt.Columns.Add("PUEL_COST_SUM", typeof(int));
                       //_dt.Rows.Add(sum);


                       DataRow _dr = _dt.NewRow();
                       _dr["PUEL_COST_SUM"] = sum;


                       this.PopupResultSet.ResultValue = "OK";
                       this.PopupResultSet.SetDataDictionary(_dr);
                       popcheck = true;
                    }
                    else
                    {
                    parent.ShowMessage("ERPE0464", "유류비 계산을 정확하게 하세요");
                         e.Cancel = true;
                         return;
                    }
                  
              
            }
            catch
            {

            }

        }

        private void CallCommand(BizCommand addRow)
        {
            throw new NotImplementedException();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl2.Focus();
            gridView2.Focus();

            gridView2.AddNewRow();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void gridControl1_AfterLoadData(object sender, Controls.AfterLoadDataEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

            //DataTable dt = gridControl2.DataSource as DataTable;

            //parent.DbClient.ExecSPTrn("up_erp_PUEL_COST_SAVE",
            //   new DbParameter("@XML_DATA", DataUtil.DataTableToXml(dt)),
            //   new DbParameter("@TRIP_NO", TRIP_NO)
            //   );

            //DataRow dr = dt.NewRow();

            //int sum = 0;
                 
            //sum = Convert.ToInt32(dt.Compute("Sum(PUEL_COST)", ""));

            //DataTable _dt = new DataTable();
            //_dt.Columns.Add("PUEL_COST_SUM", typeof(int));
            ////_dt.Rows.Add(sum);


            //DataRow _dr = _dt.NewRow();
            //_dr["PUEL_COST_SUM"] = sum;  
          

            //this.PopupResultSet.ResultValue = "OK";
            //this.PopupResultSet.SetDataDictionary(_dr);


            //popcheck = true;


            this.ParentForm.Close();
        }


 

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }
       

        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable dt = gridControl2.DataSource as DataTable;
                DataRow dr = gridView2.GetFocusedDataRow();
            
                if (dr != null)
                {  
                    try
                    {
                        if (gridView2.GetFocusedDataRow()["START_MAP"] != null && gridView2.GetFocusedDataRow()["END_MAP"] != null && gridView2.GetFocusedDataRow()["START_MAP"] != DBNull.Value && gridView2.GetFocusedDataRow()["END_MAP"] != DBNull.Value)
                        {
                            
                            int divk = 1000;
                            int divD = Convert.ToInt32(MAP.CalculateDistance(gridView2.GetFocusedDataRow()["START_LNG"] + "," + gridView2.GetFocusedDataRow()["START_LAT"], gridView2.GetFocusedDataRow()["END_LNG"] + "," + gridView2.GetFocusedDataRow()["END_LAT"]));

                            gridView2.SetRowCellValue(this.gridView2.FocusedRowHandle, gridView2.Columns["DISTANCE"],
                                //MAP.CalculateDistance(gridView2.GetFocusedDataRow()["START_LNG"] + "," + gridView2.GetFocusedDataRow()["START_LAT"], gridView2.GetFocusedDataRow()["END_LNG"] + "," + gridView2.GetFocusedDataRow()["END_LAT"])
                                String.Format("{0:N1}", ((double)divD / (double)divk))
                                );
                        }
                    }
                   catch
                    {

                    }


                    try
                    {                     
                        if (gridView2.GetFocusedDataRow()["DISTANCE"] != null&& gridView2.GetFocusedDataRow()["DIS_GB"] != null && gridView2.GetFocusedDataRow()["DISTANCE"] != DBNull.Value && gridView2.GetFocusedDataRow()["DIS_GB"] != DBNull.Value)
                        {
                            int gas ;
                            int pgas = Convert.ToInt32(PUEL.CalculateDistance(gridView2.GetFocusedDataRow()["START_LNG"] + "," + gridView2.GetFocusedDataRow()["START_LAT"], gridView2.GetFocusedDataRow()["END_LNG"] + "," + gridView2.GetFocusedDataRow()["END_LAT"]));


                            if (gridView2.GetFocusedDataRow()["DIS_GB"].ToString() == "1")
                            {
                                gas = 1;
                            }
                            else
                            {
                                gas = 2; 
                            }

                            gridView2.SetRowCellValue(this.gridView2.FocusedRowHandle, gridView2.Columns["PUEL_COST"],
                               pgas * gas * 1.2
                            );
                        }
                    }
                    catch
                    {

                    }
                }              

            }
            catch
            {

            }


           

            
             
        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["DIS_GB"],1);
            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PUEL_COST"], 0);
        }





        //private void gridView2_Click(object sender, EventArgs e)
        //{
        //    DataRow dr = this.gridView2.GetFocusedDataRow();


        //}

        //private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column.FieldName == "START_MAP" ||
        //       e.Column.FieldName == "END_MAP")
        //    {
        //        gridView2.SetRowCellValue(e.RowHandle, "DISTANCE",
        //             MAP.CalculateDistance(gridView2.GetFocusedDataRow()["START_LNG"] + "," + gridView2.GetFocusedDataRow()["START_LAT"], gridView2.GetFocusedDataRow()["END_LNG"] + "," + gridView2.GetFocusedDataRow()["END_LAT"])
        //        );

        //    };
        //}

        //private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column.FieldName == "START_MAP" ||
        //      e.Column.FieldName == "END_MAP")
        //    {
        //        gridView2.SetRowCellValue(e.RowHandle, "DISTANCE",
        //             MAP.CalculateDistance(gridView2.GetFocusedDataRow()["START_LNG"] + "," + gridView2.GetFocusedDataRow()["START_LAT"], gridView2.GetFocusedDataRow()["END_LNG"] + "," + gridView2.GetFocusedDataRow()["END_LAT"])
        //        );

        //    };
        //}




    }
}










