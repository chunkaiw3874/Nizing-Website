using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIZING_BACKEND_Data_Config
{
    public partial class frmAPA_Main : Form
    {
        //2019.11.07 停止使用特評

        #region Frame Universal Variable
        string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
        public string UserName { get; set; }
        public DataTable dtAuthorizedFunctionTable { get; set; }
        public string CurrentForm { get; set; }
        private readonly frmLogin _frmLogin;
        private enum FunctionMode { ADD, EDIT, DELETE, SEARCH, STATIC, DISABLED }
        private enum TableRowStatus { DELETED, EDITED, NEW, UNCHANGED };
        TabPage currentTabPage;
        bool isCancel = false;  //Check if an event is triggered after Cancel button is hit; deactivate cell and row validation if it's true
        #endregion

        #region 問題分類建立 Universal Variable
        private FunctionMode questionCategoryTabMode = FunctionMode.STATIC;
        private dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter adapterQuestionCategory = new dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter();
        DataTable dtQuestionCategorySource = new DataTable();
        #endregion

        #region 問題建立 Universal Variable
        private FunctionMode questionTabMode = FunctionMode.STATIC;
        private dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_QUESTION_ATableAdapter adapterQuestion = new dsAPA_QuestionTableAdapters.HR360_ASSESSMENTQUESTION_QUESTION_ATableAdapter();
        DataTable dtQuestionSource = new DataTable();
        #endregion

        #region 問題分配 Universal Variable
        private FunctionMode questionAssignmentTabMode = FunctionMode.STATIC;
        #endregion

        #region 評分權重設定 Universal Variable
        private FunctionMode setScoreWeightTabMode = FunctionMode.STATIC;
        #endregion

        #region 評核主管人數設定 Universal Variable
        private FunctionMode setSupervisorAmountTabMode = FunctionMode.STATIC;
        DataTable dtSetSupervisorAmountSource = new DataTable();
        #endregion

        #region 評核人員分配 Universal Variable
        private FunctionMode personnelAssignmentTabMode = FunctionMode.STATIC;
        DataTable dtPersonnelAssignmentSource = new DataTable();
        #endregion

        #region 員工應工作時數 Universal Variable
        private FunctionMode employeeWorkHourInputTabMode = FunctionMode.STATIC;
        DataTable dtEmployeeWorkhourSource = new DataTable();
        #endregion

        //#region 特評分數設定 Universal Variable
        //private FunctionMode scoreStandardTabMode = FunctionMode.STATIC;
        //decimal scoreStandardValue;
        //#endregion

        #region 帳號權限 Universal Variable
        private FunctionMode accountPriviledgeTabMode = FunctionMode.STATIC;
        DataTable dtAccountPriviledgeSource = new DataTable();
        #endregion

        

        public frmAPA_Main(frmLogin frmLogin)
        {            
            InitializeComponent();
            _frmLogin = frmLogin;
            currentTabPage = tbcManagement.SelectedTab;
            LoadControlStatus(currentTabPage);

            #region 問題分類建立 Initialization
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            LoadGridViewStyle(gvQuestionCategory);
            questionCategoryTabMode = FunctionMode.STATIC;
            #endregion

            #region 問題建立 Initializaiton
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            LoadGridViewStyle(gvQuestion);
            questionTabMode = FunctionMode.STATIC;
            #endregion

            #region 問題分配 Initialization
            questionAssignmentTabMode = FunctionMode.STATIC;
            #endregion

            #region 評分權重設定 Initialization
            setScoreWeightTabMode = FunctionMode.STATIC;
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                cbxSetScoreWeightYear.Items.Add(i.ToString());
            }
            cbxSetScoreWeightYear.SelectedIndex = 0;
            #endregion

            #region 評核主管人數設定 Init
            setSupervisorAmountTabMode = FunctionMode.STATIC;
            for(int i = DateTime.Today.Year; i >= 2016; i--)
            {
                cbxSetSupervisorAmountYear.Items.Add(i);
            }
            cbxSetSupervisorAmountYear.SelectedIndex = 0;
            #endregion

            #region 評核人員分配 Initialization
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                cbxPersonnelAssignmentYear.Items.Add(i.ToString());
            }
            cbxPersonnelAssignmentYear.SelectedIndex = 0;            
            personnelAssignmentTabMode = FunctionMode.STATIC;
            #endregion

            #region 員工應工作時數 Init
            employeeWorkHourInputTabMode = FunctionMode.STATIC;
            for (int i = DateTime.Today.Year; i >= 2016; i--)
            {
                cbxEmployeeWorkhourInputYear.Items.Add(i);
            }
            cbxEmployeeWorkhourInputYear.Text = (DateTime.Today.Year - 1).ToString();
            //dtEmployeeWorkhourSource = LoadgvEmployeeWorkhourInputField();
            //gvEmployeeWorkhourInputField.DataSource = dtEmployeeWorkhourSource;
            //LoadGridViewStyle(gvEmployeeWorkhourInputField);
            #endregion          
            
            //#region 特評分數設定 Init
            //scoreStandardTabMode = FunctionMode.STATIC;
            //LoadScoreStandard();
            //#endregion

            #region 帳號權限 Init
            dtAccountPriviledgeSource = LoadgvAccountPriviledge();
            gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
            accountPriviledgeTabMode = FunctionMode.STATIC;
            #endregion

            #region 報表預覽 Init
            for (int i = DateTime.Today.Year; i >= 2016; i--)
            {
                cbxReportPreviewYear.Items.Add(i);
            }
            cbxReportPreviewYear.SelectedIndex = 0;
            btnReportPreviewPreview.Enabled = false;
            cbxReportPreviewEmployee.Enabled = false;
            cbxReportPreviewYear.Enabled = false;
            #endregion

            #region 年份及評核時間設定 Init
            dtpYearAndEvalTimeStartTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeEndTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeSelfStartTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeSelfStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeSelfEndTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeSelfEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeSupervisorStartTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeSupervisorStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeSupervisorEndTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeSupervisorEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeFinalizerStartTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeFinalizerStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpYearAndEvalTimeFinalizerEndTime.Format = DateTimePickerFormat.Custom;
            dtpYearAndEvalTimeFinalizerEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            for (int i = DateTime.Today.Year; i >= 2016; i--)
            {
                cbxYearAndEvalTimeYear.Items.Add(i);
            }
            cbxYearAndEvalTimeYear.SelectedIndex = 0;
            #endregion

            #region 最終成績計算 Universal Variable
            for (int i = DateTime.Today.Year; i >= 2016; i--)
            {
                cbxFinalScoreYear.Items.Add(i);
            }
            cbxFinalScoreYear.SelectedIndex = cbxFinalScoreYear.Items.Count - 1;
            cbxFinalScoreYear.Enabled = false;
            btnFinalScoreCalculate.Enabled = false;
            txtFinalScoreMemo.Enabled = false;
            txtFinalScoreMemo.Text = string.Empty;
            #endregion

        }

        //public frmAPA_Main()
        //{
        //    InitializeComponent();
        //    currentTabPage = tbcManagement.SelectedTab;
        //    LoadControlStatus(currentTabPage);

        //    #region 問題分類建立 Initialization
        //    dtQuestionCategorySource = adapterQuestionCategory.GetData();
        //    gvQuestionCategory.DataSource = dtQuestionCategorySource;
        //    LoadGridViewStyle(gvQuestionCategory);
        //    questionCategoryTabMode = FunctionMode.STATIC;
        //    #endregion
        //    #region 問題建立 Initializaiton
        //    dtQuestionSource = adapterQuestion.GetData();
        //    gvQuestion.DataSource = dtQuestionSource;
        //    LoadGridViewStyle(gvQuestion);
        //    questionTabMode = FunctionMode.STATIC;
        //    #endregion
        //    #region 評核人員分配 Initialization
        //    for (int i = DateTime.Now.Year; i >= 2016; i--)
        //    {
        //        cbxPersonnelAssignmentYear.Items.Add(i.ToString());
        //    }
        //    cbxPersonnelAssignmentYear.SelectedIndex = 0;
        //    dtPersonnelAssignmentSource = LoadgvPersonnelAssignment();
        //    gvPersonnelAssignment.DataSource = dtPersonnelAssignmentSource;
        //    LoadGridViewStyle(gvPersonnelAssignment);
        //    personnelAssignmentTabMode = FunctionMode.STATIC;
        //    #endregion
        //    #region 問題分配 Initialization
        //    questionAssignmentTabMode = FunctionMode.STATIC;
        //    #endregion
        //    //#region 特評分數設定 Init
        //    //scoreStandardTabMode = FunctionMode.STATIC;
        //    //LoadScoreStandard();
        //    //#endregion
        //    #region 帳號權限 Init
        //    dtAccountPriviledgeSource = LoadgvAccountPriviledge();
        //    gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
        //    LoadControlStatus(tbpAccountPriviledge);
        //    accountPriviledgeTabMode = FunctionMode.STATIC;
        //    #endregion
        //    #region 報表預覽 Init
        //    for (int i = DateTime.Today.Year; i >= 2016; i--)
        //    {
        //        cbxReportPreviewYear.Items.Add(i);
        //    }
        //    cbxReportPreviewYear.SelectedIndex = 0;
        //    btnReportPreviewPreview.Enabled = false;
        //    cbxReportPreviewEmployee.Enabled = false;
        //    cbxReportPreviewYear.Enabled = false;
        //    #endregion
        //    #region 最終成績計算 Universal Variable
        //    for (int i = DateTime.Today.Year - 1; i >= 2016; i--)
        //    {
        //        cbxFinalScoreYear.Items.Add(i);
        //    }
        //    cbxFinalScoreYear.SelectedIndex = 0;
        //    cbxFinalScoreYear.Enabled = false;
        //    btnFinalScoreCalculate.Enabled = false;
        //    txtFinalScoreMemo.Enabled = false;
        //    txtFinalScoreMemo.Text = string.Empty;
        //    #endregion  
        //    #region 年份及評核時間設定 Init
        //    dtpYearAndEvalTimeStartTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    dtpYearAndEvalTimeEndTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    dtpYearAndEvalTimeSelfStartTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeSelfStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    dtpYearAndEvalTimeSelfEndTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeSelfEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    dtpYearAndEvalTimeSupervisorStartTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeSupervisorStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    dtpYearAndEvalTimeSupervisorEndTime.Format = DateTimePickerFormat.Custom;
        //    dtpYearAndEvalTimeSupervisorEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        //    for (int i = DateTime.Today.Year - 1; i >= 2016; i--)
        //    {
        //        cbxYearAndEvalTimeYear.Items.Add(i);
        //    }
        //    cbxYearAndEvalTimeYear.SelectedIndex = 0;            

        //    //DisplayYearAndEvalTime(Convert.ToInt32(cbxYearAndEvalTimeYear.Text));
        //    #endregion
        //    #region 員工應工作時數 Init
        //    employeeWorkHourInputTabMode = FunctionMode.STATIC;
        //    for (int i = DateTime.Today.Year; i >= 2016; i--)
        //    {
        //        cbxEmployeeWorkhourInputYear.Items.Add(i);
        //    }
        //    cbxEmployeeWorkhourInputYear.Text = (DateTime.Today.Year - 1).ToString();
        //    dtEmployeeWorkhourSource = LoadgvEmployeeWorkhourInputField();
        //    gvEmployeeWorkhourInputField.DataSource = dtEmployeeWorkhourSource;
        //    LoadGridViewStyle(gvEmployeeWorkhourInputField);
        //    #endregion
        //}

        private void frmAPA_Shown(object sender, EventArgs e)
        {
            _frmLogin.LoadCbxFunctionList(this);
        }

        #region Frame Methods and Events
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void cbxFunctionList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _frmLogin.ChangeForm(this, cbxFunctionList.SelectedValue.ToString());
        }

        private void frmAPA_Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A' table. You can move, or remove it, as needed.
            this.hR360_ASSESSMENTQUESTION_CATEGORY_ATableAdapter.Fill(this.dsAPA_Question.HR360_ASSESSMENTQUESTION_CATEGORY_A);
        }
        private void tbcManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (questionCategoryTabMode == FunctionMode.STATIC
                && questionTabMode == FunctionMode.STATIC
                && personnelAssignmentTabMode == FunctionMode.STATIC
                && questionAssignmentTabMode == FunctionMode.STATIC
                //&& scoreStandardTabMode == FunctionMode.STATIC
                && accountPriviledgeTabMode == FunctionMode.STATIC
                && employeeWorkHourInputTabMode == FunctionMode.STATIC
                && setScoreWeightTabMode == FunctionMode.STATIC
                )
            {
                currentTabPage = tbcManagement.SelectedTab;
                LoadControlStatus(currentTabPage);
            }
            else
            {
                tbcManagement.SelectedTab = currentTabPage;
            }
        }
        private void LoadControlStatus(TabPage tab)
        {
            switch (tab.Name)
            {
                case "tbpQuestionCategory":
                    switch (questionCategoryTabMode)
                    {
                        case FunctionMode.STATIC:
                            btnQuestionCategoryEdit.Enabled = true;
                            btnQuestionCategorySave.Enabled = false;
                            btnQuestionCategoryCancel.Enabled = false;
                            gvQuestionCategory.ReadOnly = true;
                            gvQuestionCategory.ForeColor = Color.Gray;
                            break;
                        case FunctionMode.EDIT:
                            btnQuestionCategoryEdit.Enabled = false;
                            btnQuestionCategorySave.Enabled = true;
                            btnQuestionCategoryCancel.Enabled = true;
                            gvQuestionCategory.ReadOnly = false;
                            gvQuestionCategory.ForeColor = Color.Black;
                            LoadGridViewStyle(gvQuestionCategory);
                            break;
                    }
                    break;
                case "tbpQuestion":
                    switch (questionTabMode)
                    {
                        case FunctionMode.STATIC:
                            btnQuestionEdit.Enabled = true;
                            btnQuestionSave.Enabled = false;
                            btnQuestionCancel.Enabled = false;
                            gvQuestion.ReadOnly = true;
                            gvQuestion.ForeColor = Color.Gray;
                            break;
                        case FunctionMode.EDIT:
                            btnQuestionEdit.Enabled = false;
                            btnQuestionSave.Enabled = true;
                            btnQuestionCancel.Enabled = true;
                            gvQuestion.ReadOnly = false;
                            gvQuestion.ForeColor = Color.Black;
                            LoadGridViewStyle(gvQuestion);
                            break;
                    }
                    break;
                case "tbpQuestionAssignment":
                    switch (questionAssignmentTabMode)
                    {
                        case FunctionMode.STATIC:
                            tlpQuestionAssignmentAll.Enabled = false;
                            break;
                        case FunctionMode.EDIT:
                            tlpQuestionAssignmentAll.Enabled = true;
                            break;
                    }
                    break;
                case "tbpSetScoreWeight":
                    if (isEvalDone(Convert.ToInt32(cbxSetScoreWeightYear.Text)))
                    {
                        btnSetScoreWeightEdit.Enabled = false;
                        cbxSetScoreWeightYear.Enabled = true;
                        txtSetScoreWeightSelfWeight.Enabled = false;
                        txtSetScoreWeightSupervisorWeight.Enabled = false;
                        txtSetScoreWeightFinalizerWeight.Enabled = false;
                        btnSetScoreWeightSave.Enabled = false;
                        btnSetScoreWeightCancel.Enabled = false;
                    }
                    else
                    {
                        switch (setScoreWeightTabMode)
                        {
                            case FunctionMode.STATIC:
                                btnSetScoreWeightEdit.Enabled = true;
                                cbxSetScoreWeightYear.Enabled = true;
                                txtSetScoreWeightSelfWeight.Enabled = false;
                                txtSetScoreWeightSupervisorWeight.Enabled = false;
                                txtSetScoreWeightFinalizerWeight.Enabled = false;
                                btnSetScoreWeightSave.Enabled = false;
                                btnSetScoreWeightCancel.Enabled = false;
                                break;
                            case FunctionMode.EDIT:
                                btnSetScoreWeightEdit.Enabled = false;
                                cbxSetScoreWeightYear.Enabled = true;
                                txtSetScoreWeightSelfWeight.Enabled = true;
                                txtSetScoreWeightSupervisorWeight.Enabled = true;
                                txtSetScoreWeightFinalizerWeight.Enabled = true;
                                btnSetScoreWeightSave.Enabled = true;
                                btnSetScoreWeightCancel.Enabled = true;
                                break;
                        }

                    }
                    break;
                case "tbpSetSupervisorAmount":
                    if (isEvalDone(Convert.ToInt32(cbxSetSupervisorAmountYear.Text)))
                    {
                        cbxSetSupervisorAmountYear.Enabled = true;
                        btnSetSupervisorAmountEdit.Enabled = false;
                        gvSetSupervisorAmountInputField.ReadOnly = true;
                        gvSetSupervisorAmountInputField.ForeColor = Color.Gray;
                        btnSetSupervisorAmountSave.Enabled = false;
                        btnSetSupervisorAmountCancel.Enabled = false;
                        DisplaySetSupervisorAmountData(Convert.ToInt32(cbxSetSupervisorAmountYear.Text));
                    }
                    else
                    {
                        switch(setSupervisorAmountTabMode)
                        {
                            case FunctionMode.STATIC:
                                cbxSetSupervisorAmountYear.Enabled = true;
                                btnSetSupervisorAmountEdit.Enabled = true;
                                gvSetSupervisorAmountInputField.ReadOnly = true;
                                gvSetSupervisorAmountInputField.ForeColor = Color.Gray;
                                btnSetSupervisorAmountSave.Enabled = false;
                                btnSetSupervisorAmountCancel.Enabled = false;
                                DisplaySetSupervisorAmountData(Convert.ToInt32(cbxSetSupervisorAmountYear.Text));
                                break;
                            case FunctionMode.EDIT:
                                cbxSetSupervisorAmountYear.Enabled = false;
                                btnSetSupervisorAmountEdit.Enabled = false;
                                gvSetSupervisorAmountInputField.ReadOnly = false;
                                gvSetSupervisorAmountInputField.ForeColor = Color.Black;
                                btnSetSupervisorAmountSave.Enabled = true;
                                btnSetSupervisorAmountCancel.Enabled = true;
                                DisplaySetSupervisorAmountData(Convert.ToInt32(cbxSetSupervisorAmountYear.Text));
                                break;
                            case FunctionMode.DISABLED:
                                cbxSetSupervisorAmountYear.Enabled = true;
                                btnSetSupervisorAmountEdit.Enabled = false;
                                gvSetSupervisorAmountInputField.ReadOnly = true;
                                gvSetSupervisorAmountInputField.ForeColor = Color.Gray;
                                btnSetSupervisorAmountSave.Enabled = false;
                                btnSetSupervisorAmountCancel.Enabled = false;
                                DisplaySetSupervisorAmountData(Convert.ToInt32(cbxSetSupervisorAmountYear.Text));
                                break;
                        }
                    }
                    break;
                case "tbpPersonnelAssignment":
                    if (isEvalDone(Convert.ToInt32(cbxPersonnelAssignmentYear.Text)))
                    {
                        btnPersonnelAssignmentEdit.Enabled = false;
                        btnPersonnelAssignmentClearData.Enabled = false;
                        btnPersonnelAssignmentSave.Enabled = false;
                        btnPersonnelAssignmentCancel.Enabled = false;                        
                        cbxPersonnelAssignmentYear.Enabled = true;
                        gvPersonnelAssignment.ReadOnly = true;
                        gvPersonnelAssignment.ForeColor = Color.Gray;
                        DisplayPersonnelAssignmentData(Convert.ToInt32(cbxPersonnelAssignmentYear.Text));
                    }
                    else
                    {
                        switch (personnelAssignmentTabMode)
                        {
                            case FunctionMode.STATIC:
                                btnPersonnelAssignmentEdit.Enabled = true;
                                btnPersonnelAssignmentClearData.Enabled = true;
                                btnPersonnelAssignmentSave.Enabled = false;
                                btnPersonnelAssignmentCancel.Enabled = false;
                                cbxPersonnelAssignmentYear.Enabled = true;
                                gvPersonnelAssignment.ReadOnly = true;
                                gvPersonnelAssignment.ForeColor = Color.Gray;
                                DisplayPersonnelAssignmentData(Convert.ToInt32(cbxPersonnelAssignmentYear.Text));
                                break;
                            case FunctionMode.EDIT:
                                btnPersonnelAssignmentEdit.Enabled = false;
                                btnPersonnelAssignmentClearData.Enabled = false;
                                btnPersonnelAssignmentSave.Enabled = true;
                                btnPersonnelAssignmentCancel.Enabled = true;
                                cbxPersonnelAssignmentYear.Enabled = false;
                                gvPersonnelAssignment.ReadOnly = false;
                                gvPersonnelAssignment.ForeColor = Color.Black;
                                DisplayPersonnelAssignmentData(Convert.ToInt32(cbxPersonnelAssignmentYear.Text));
                                break;
                        }
                    }
                    break;
                case "tbpEmployeeWorkhourInput":
                    if (isEvalDone(Convert.ToInt32(cbxEmployeeWorkhourInputYear.Text)))
                    {
                        cbxEmployeeWorkhourInputYear.Enabled = true;
                        btnEmployeeWorkhourInputEdit.Enabled = false;
                        btnEmployeeWorkhourInputSave.Enabled = false;
                        btnEmployeeWorkhourInputCancel.Enabled = false;
                        gvEmployeeWorkhourInputField.ReadOnly = true;
                        gvEmployeeWorkhourInputField.ForeColor = Color.Gray;
                        LoadGridViewStyle(gvEmployeeWorkhourInputField);
                    }
                    else
                    {
                        switch (employeeWorkHourInputTabMode)
                        {
                            case FunctionMode.STATIC:
                                cbxEmployeeWorkhourInputYear.Enabled = true;
                                btnEmployeeWorkhourInputEdit.Enabled = true;
                                btnEmployeeWorkhourInputSave.Enabled = false;
                                btnEmployeeWorkhourInputCancel.Enabled = false;
                                gvEmployeeWorkhourInputField.ReadOnly = true;
                                gvEmployeeWorkhourInputField.ForeColor = Color.Gray;
                                LoadGridViewStyle(gvEmployeeWorkhourInputField);
                                break;
                            case FunctionMode.EDIT:
                                cbxEmployeeWorkhourInputYear.Enabled = false;
                                btnEmployeeWorkhourInputEdit.Enabled = false;
                                btnEmployeeWorkhourInputSave.Enabled = true;
                                btnEmployeeWorkhourInputCancel.Enabled = true;
                                gvEmployeeWorkhourInputField.ReadOnly = false;
                                gvEmployeeWorkhourInputField.ForeColor = Color.Black;
                                LoadGridViewStyle(gvEmployeeWorkhourInputField);
                                break;
                        }
                    }
                    break;
                
                //case "tbpScoreStandard":    //2019.11.05 停止使用特評
                //    switch (scoreStandardTabMode)
                //    {
                //        case FunctionMode.STATIC:
                //            btnScoreStandardEdit.Enabled = false;
                //            btnScoreStandardSave.Enabled = false;
                //            btnScoreStandardCancel.Enabled = false;
                //            txtScoreStandardStandard.Enabled = false;
                //            break;
                //        case FunctionMode.EDIT:
                //            btnScoreStandardEdit.Enabled = false;
                //            btnScoreStandardSave.Enabled = false;
                //            btnScoreStandardCancel.Enabled = false;
                //            txtScoreStandardStandard.Enabled = false;
                //            break;
                //    }
                //    break;
                
                case "tbpYearAndEvalTime":
                    if (isEvalDone(Convert.ToInt32(cbxYearAndEvalTimeYear.Text)))
                    {
                        btnYearAndEvalTimeSave.Enabled = false;
                    }
                    else
                    {
                        btnYearAndEvalTimeSave.Enabled = true;
                    }
                    break;
                case "tbpAccountPriviledge":
                    switch (accountPriviledgeTabMode)
                    {
                        case FunctionMode.STATIC:
                            btnAccountPriviledgeEdit.Enabled = true;
                            btnAccountPriviledgeSave.Enabled = false;
                            btnAccountPriviledgeCancel.Enabled = false;
                            gvAccountPriviledge.ReadOnly = true;
                            gvAccountPriviledge.ForeColor = Color.Gray;
                            LoadGridViewStyle(gvAccountPriviledge);
                            break;
                        case FunctionMode.EDIT:
                            btnAccountPriviledgeEdit.Enabled = false;
                            btnAccountPriviledgeSave.Enabled = true;
                            btnAccountPriviledgeCancel.Enabled = true;
                            gvAccountPriviledge.ReadOnly = false;
                            gvAccountPriviledge.ForeColor = Color.Black;
                            LoadGridViewStyle(gvAccountPriviledge);
                            break;
                    }
                    break;
                
                case "tbpReportPreview":
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT ERP_ID"
                                    + " FROM HR360_ASSESSMENTPRIVILEDGE"
                                    + " WHERE ERP_ID=@ID"
                                    + " AND [VIEW]=1";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", UserName);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                {
                                    btnReportPreviewPreview.Enabled = true;
                                    cbxReportPreviewEmployee.Enabled = true;
                                    cbxReportPreviewYear.Enabled = true;
                                }
                            }
                        }
                    }
                    break;
                case "tbpFinalScoreCalculation":
                    if (isEvalDone(Convert.ToInt32(cbxFinalScoreYear.Text)))
                    {
                        cbxFinalScoreYear.Enabled = true;
                        btnFinalScoreCalculate.Enabled = false;
                        btnFinalScoreAssessmentDone.Enabled = false;
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                        {
                            conn.Open();
                            string query = "SELECT ERP_ID"
                                        + " FROM HR360_ASSESSMENTPRIVILEDGE"
                                        + " WHERE ERP_ID=@ID"
                                        + " AND [CALCULATE]=1";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ID", UserName);
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {
                                        cbxFinalScoreYear.Enabled = true;
                                        btnFinalScoreCalculate.Enabled = true;
                                    }
                                }
                            }
                        }
                        btnFinalScoreAssessmentDone.Enabled = true;
                    }
                    break;
            }
        }
        private void CompareTables(DataTable dtOriginal, DataTable dtChanged)
        {
            if (!dtOriginal.Columns.Contains("EDIT_STATUS"))
            {
                dtOriginal.Columns.Add("EDIT_STATUS");
            }
            if (!dtChanged.Columns.Contains("EDIT_STATUS"))
            {
                dtChanged.Columns.Add("EDIT_STATUS");
            }

            for (int i = 0; i < dtChanged.Rows.Count; i++)
            {
                if (dtChanged.Rows[i].RowState != DataRowState.Deleted)
                {
                    for (int y = 0; y < dtOriginal.Rows.Count; y++)
                    {
                        if (dtOriginal.Rows[y][0].ToString() == dtChanged.Rows[i][0].ToString())  //找到兩個dt中UID相同的row，執行對比
                        {
                            for (int z = 1; z < dtOriginal.Columns.Count - 1; z++)
                            {
                                if (dtOriginal.Rows[y][z].ToString().Trim() != dtChanged.Rows[i][z].ToString().Trim())    //有cell值不相同，表示此row有被edit過
                                {
                                    dtOriginal.Rows[y]["EDIT_STATUS"] = TableRowStatus.EDITED;
                                    dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.EDITED;
                                    break;
                                }
                            }
                            if (String.IsNullOrWhiteSpace(dtChanged.Rows[i]["EDIT_STATUS"].ToString()))
                            {
                                dtOriginal.Rows[y]["EDIT_STATUS"] = TableRowStatus.UNCHANGED;
                                dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.UNCHANGED;
                            }
                            break;
                        }
                    }
                    if (String.IsNullOrWhiteSpace(dtChanged.Rows[i]["EDIT_STATUS"].ToString()))
                    {
                        dtChanged.Rows[i]["EDIT_STATUS"] = TableRowStatus.NEW;
                    }
                }
            }
            for (int i = 0; i < dtOriginal.Rows.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(dtOriginal.Rows[i]["EDIT_STATUS"].ToString()))
                {
                    dtOriginal.Rows[i][dtOriginal.Columns.Count - 1] = TableRowStatus.DELETED;
                }
            }

        }
        private void LoadGridViewStyle(DataGridView gv)
        {
            switch (gv.Name)
            {
                case "gvQuestionCategory":
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["ID"].ReadOnly = true;
                    gv.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["權重"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "gvQuestion":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["ID"].ReadOnly = true;
                    gv.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["問題"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //change gv column to multiline
                    gv.Columns["問題"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gv.Columns["分類"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["使用中"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["全體共用"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataTable dtgvQuestionTemp = adapterQuestionCategory.GetData();
                    dtgvQuestionTemp.Columns.Add("ID_NAME");
                    foreach (DataRow rows in dtgvQuestionTemp.Rows)
                    {
                        rows["ID_NAME"] = rows["ID"].ToString() + " " + rows["名稱"].ToString();
                    }
                    foreach (DataGridViewRow row in gv.Rows)
                    {
                        DataGridViewCheckBoxCell ckbIN_USECell = new DataGridViewCheckBoxCell()
                        {
                            TrueValue = "1",
                            FalseValue = "0"
                        };
                        ckbIN_USECell.Style.NullValue = false;
                        row.Cells["使用中"] = ckbIN_USECell;
                        DataGridViewCheckBoxCell ckbUSE_BY_ALLCell = new DataGridViewCheckBoxCell()
                        {
                            TrueValue = "1",
                            FalseValue = "0"
                        };
                        ckbUSE_BY_ALLCell.Style.NullValue = false;
                        row.Cells["全體共用"] = ckbUSE_BY_ALLCell;
                        DataGridViewComboBoxCell cbxCATEGORY_IDCell = new DataGridViewComboBoxCell();
                        cbxCATEGORY_IDCell.FlatStyle = FlatStyle.Flat;
                        cbxCATEGORY_IDCell.DataSource = dtgvQuestionTemp;
                        cbxCATEGORY_IDCell.ValueMember = "ID";
                        cbxCATEGORY_IDCell.DisplayMember = "ID_NAME";
                        row.Cells["分類"] = cbxCATEGORY_IDCell;
                    }
                    break;
                case "gvSetSupervisorAmountInputField":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["評核年份"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["評核年份"].ReadOnly = true;
                    gv.Columns["員工ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["員工ID"].ReadOnly = true;
                    gv.Columns["員工姓名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["員工姓名"].ReadOnly = true;
                    gv.Columns["評核主管人數"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["核決主管人數"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["核決主管人數"].ReadOnly = true;
                    break;
                case "gvPersonnelAssignment":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["年份"].ReadOnly = true;
                    gv.Columns["年份"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["受評者"].ReadOnly = true;
                    gv.Columns["評核順位"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["評核順位"].ReadOnly = true;
                    gv.Columns["評核類型"].ReadOnly = true;
                    DataTable dtAssessorList = new DataTable();
                    using (SqlConnection conn = new SqlConnection(NZConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT LTRIM(RTRIM(MV.MV001))+' '+LTRIM(RTRIM(MV.MV002)) 'NAME',LTRIM(RTRIM(MV.MV001)) 'ID'"
                                    + " FROM CMSMV MV"
                                    + " WHERE "
                                    + " (MV.MV022=''"
                                    + " OR MV.MV022 > @YEAR+'1232')"
                                    + " AND MV.MV021 < @YEAR+'1232'"
                                    + " AND MV.MV001 NOT LIKE 'PT%'"
                                    + " AND MV.MV001<>'0000'"
                                    + " AND MV.MV001<>'0098'"
                                    + " ORDER BY MV.MV001";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@YEAR", cbxPersonnelAssignmentYear.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtAssessorList);
                    }
                    foreach (DataGridViewRow row in gv.Rows)
                    {
                        DataGridViewComboBoxCell cbxAssessorCell = new DataGridViewComboBoxCell();
                        cbxAssessorCell.FlatStyle = FlatStyle.Flat;
                        cbxAssessorCell.MaxDropDownItems = 5;
                        cbxAssessorCell.DataSource = dtAssessorList;
                        cbxAssessorCell.DisplayMember = "NAME";
                        cbxAssessorCell.ValueMember = "NAME";
                        row.Cells["評核者"] = cbxAssessorCell;
                        if (row.Cells["評核類型"].FormattedValue.ToString() == "1. 自評") //2019年開始，自評為唯一自動產生的分類
                        {
                            row.ReadOnly = true;
                        }
                        if (row.ReadOnly == true)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                    break;
                case "gvAccountPriviledge":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["帳號"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["閱覽報表權限"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["計算成績權限"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataTable dtAccountList = new DataTable();
                    using (SqlConnection conn = new SqlConnection(NZConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT LTRIM(RTRIM(MV.MV001))+' '+LTRIM(RTRIM(MV.MV002)) 'NAME',LTRIM(RTRIM(MV.MV001)) 'ID'"
                                    + " FROM CMSMV MV"
                                    + " WHERE "
                                    + " MV.MV022=''"
                                    + " AND MV.MV001 NOT LIKE 'PT%'"
                                    + " AND MV.MV001<>'0000'"
                                    + " AND MV.MV001<>'0098'"
                                    + " ORDER BY MV.MV001";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtAccountList);
                    }
                    foreach (DataGridViewRow row in gv.Rows)
                    {
                        DataGridViewCheckBoxCell ckbView = new DataGridViewCheckBoxCell()
                        {
                            TrueValue = 1,
                            FalseValue = 0
                        };
                        ckbView.Style.NullValue = false;
                        row.Cells["閱覽報表權限"] = ckbView;
                        ckbView = new DataGridViewCheckBoxCell()
                        {
                            TrueValue=1,
                            FalseValue=0
                        };
                        ckbView.Style.NullValue = false;
                        row.Cells["計算成績權限"] = ckbView;
                        DataGridViewComboBoxCell cbxAccountCell = new DataGridViewComboBoxCell();
                        cbxAccountCell.FlatStyle = FlatStyle.Flat;
                        cbxAccountCell.MaxDropDownItems = 5;
                        cbxAccountCell.DataSource = dtAccountList;
                        cbxAccountCell.DisplayMember = "NAME";
                        cbxAccountCell.ValueMember = "NAME";
                        row.Cells["帳號"] = cbxAccountCell;
                    }
                    break;
                case "gvEmployeeWorkhourInputField":
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["評核年份"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["評核年份"].ReadOnly = true;
                    gv.Columns["員工ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["員工ID"].ReadOnly = true;
                    gv.Columns["員工姓名"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gv.Columns["員工姓名"].ReadOnly = true;
                    gv.Columns["應工作時數"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
            }
        }
        private bool isEvalDone(int year)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "select EVAL_DONE" +
                    " from HR360_ASSESSMENTTIME" +
                    " where EVAL_YEAR=@YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", year);

                return (bool?)cmd.ExecuteScalar() == null ? false : (bool)cmd.ExecuteScalar();
            }
        }
        private string GetErrorMessage(int errorCode)
        {
            string message = "";
            switch (errorCode)
            {
                case 101:
                    message = "儲存格不得空白";
                    break;
                case 102:
                    message = "儲存格值型態錯誤";
                    break;
                case 201:
                    message = "尚有空白儲存格，請將資料完整填寫";
                    break;
                case 401:
                    message = "資料刪除錯誤";
                    break;
                case 999:
                    message = "其他錯誤";
                    break;
                default:
                    message = "未知錯誤";
                    break;
            }
            return message;
        }
        private void ShowError(int errorCode)
        {
            MessageBox.Show(GetErrorMessage(errorCode));
        }
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
        private void gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadGridViewStyle((DataGridView)sender);
        }
        #endregion

        #region 問題分類建立 Tab Method and Events
        private void gvQuestionCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isCancel)
            {
                if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    ShowError(101);
                    e.Cancel = true;
                }
                else if (e.ColumnIndex == 0)
                {
                    int result;
                    if (!int.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    decimal result;
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void gvQuestionCategory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!isCancel)
            {
                foreach (DataGridViewCell c in gvQuestionCategory.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                    {
                        ShowError(201);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void gvQuestionCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {

                if (gvQuestionCategory.CurrentRow.Index == gvQuestionCategory.Rows.Count - 1)
                {
                    foreach (DataGridViewCell c in gvQuestionCategory.CurrentRow.Cells)
                    {
                        if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                        {
                            ShowError(201);
                            e.Handled = true;
                            break;
                        }
                    }
                    if (!e.Handled)
                    {
                        DataRow newRow = dtQuestionCategorySource.NewRow();
                        newRow["ID"] = (Convert.ToInt16(gvQuestionCategory.CurrentRow.Cells[0].EditedFormattedValue) + 1).ToString("D2");
                        dtQuestionCategorySource.Rows.Add(newRow);
                        gvQuestionCategory.DataSource = dtQuestionCategorySource;
                        if (gvQuestionCategory.Rows.Count > 1 && gvQuestionCategory.Enabled == true)
                        {
                            gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[gvQuestionCategory.CurrentRow.Index + 1].Cells[0];
                        }
                    }
                }
            }
        }
        private void btnQuestionCategoryEdit_Click(object sender, EventArgs e)
        {
            questionCategoryTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvQuestionCategory.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }
        private void btnQuestionCategorySave_Click(object sender, EventArgs e)
        {
            DataTable dtOriginalTable = adapterQuestionCategory.GetData();
            tbcManagement.Enabled = false;
            gvQuestionCategory.DataSource = null;
            CompareTables(dtOriginalTable, dtQuestionCategorySource);
            var tempRow = dtQuestionCategorySource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.EDITED.ToString()).OrderBy(y => y["ID"]);
            DataTable dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionCategorySource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestionCategory.UpdateQuery(UserName, dtSourceInterim.Rows[i]["名稱"].ToString().Trim(), dtSourceInterim.Rows[i]["權重"].ToString().Trim(), dtSourceInterim.Rows[i]["ID"].ToString().Trim());
            }
            tempRow = dtQuestionCategorySource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionCategorySource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestionCategory.InsertQuery(UserName, dtSourceInterim.Rows[i]["ID"].ToString().Trim(), dtSourceInterim.Rows[i]["名稱"].ToString().Trim(), dtSourceInterim.Rows[i]["權重"].ToString().Trim());
            }
            tempRow = dtOriginalTable.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.DELETED.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOriginalTable.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                try
                {
                    adapterQuestionCategory.DeleteQuery(dtSourceInterim.Rows[i]["ID"].ToString().Trim());
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 547:
                            ShowError("ID:" + dtSourceInterim.Rows[i]["ID"].ToString().Trim() + dtSourceInterim.Rows[i]["名稱"].ToString().Trim() + " 已連結至其他資料，不可刪除");
                            break;
                        default:
                            ShowError(401);
                            break;
                    }
                }
            }
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            tbcManagement.Enabled = true;
            questionCategoryTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            txtQuestionCategoryTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
        }
        private void btnQuestionCategoryCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            if (gvQuestionCategory.Rows[gvQuestionCategory.Rows.Count - 1].IsNewRow)
            {
                gvQuestionCategory.Rows.RemoveAt(gvQuestionCategory.Rows.Count - 1);
            }
            dtQuestionCategorySource = adapterQuestionCategory.GetData();
            gvQuestionCategory.DataSource = dtQuestionCategorySource;
            questionCategoryTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            isCancel = false;
            txtQuestionCategoryTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
        }
        #endregion

        #region 問題建立 Tab Method and Events
        private void gvQuestion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isCancel)
            {
                if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    ShowError(101);
                    e.Cancel = true;
                }
                else if (e.ColumnIndex == 0)
                {
                    int result;
                    if (!int.TryParse(e.FormattedValue.ToString(), out result))
                    {
                        ShowError(102);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void gvQuestion_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!isCancel)
            {
                foreach (DataGridViewCell c in gvQuestion.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                    {
                        ShowError(201);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
        private void btnQuestionEdit_Click(object sender, EventArgs e)
        {
            questionTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvQuestion.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }
        private void btnQuestionCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            if (gvQuestion.Rows[gvQuestion.Rows.Count - 1].IsNewRow)
            {
                gvQuestion.Rows.RemoveAt(gvQuestion.Rows.Count - 1);
            }
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            questionTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            txtQuestionTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
            isCancel = false;
        }
        private void gvQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (questionTabMode == FunctionMode.EDIT)
            {
                if (e.KeyData == Keys.Down)
                {
                    if (gvQuestion.CurrentRow.Index == gvQuestion.Rows.Count - 1)
                    {
                        foreach (DataGridViewCell c in gvQuestion.CurrentRow.Cells)
                        {
                            if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                            {
                                ShowError(201);
                                e.Handled = true;
                                break;
                            }
                        }
                        if (!e.Handled)
                        {
                            DataRow newRow = dtQuestionSource.NewRow();
                            newRow["ID"] = (Convert.ToInt16(gvQuestion.CurrentRow.Cells[0].EditedFormattedValue) + 1).ToString();
                            dtQuestionSource.Rows.Add(newRow);
                            gvQuestion.DataSource = dtQuestionSource;
                            if (gvQuestion.Rows.Count > 1 && gvQuestion.Enabled == true)
                            {
                                gvQuestion.CurrentCell = gvQuestion.Rows[gvQuestion.CurrentRow.Index + 1].Cells[0];
                            }
                        }
                    }
                }
            }
        }
        private void btnQuestionSave_Click(object sender, EventArgs e)
        {
            DataTable dtOriginalTable = adapterQuestion.GetData();
            tbcManagement.Enabled = false;
            gvQuestion.DataSource = null;
            CompareTables(dtOriginalTable, dtQuestionSource);
            var tempRow = dtQuestionSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.EDITED.ToString()).OrderBy(y => y["ID"]);
            DataTable dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionSource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                adapterQuestion.UpdateQuery(UserName, dtSourceInterim.Rows[i]["問題"].ToString().Trim(), dtSourceInterim.Rows[i]["分類"].ToString(), dtSourceInterim.Rows[i]["使用中"].ToString(), dtSourceInterim.Rows[i]["全體共用"].ToString(), Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()));
            }
            tempRow = dtQuestionSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtQuestionSource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["使用中"].ToString()))
                {
                    dtSourceInterim.Rows[i]["使用中"] = "0";
                }
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["全體共用"].ToString()))
                {
                    dtSourceInterim.Rows[i]["全體共用"] = "0";
                }
                adapterQuestion.InsertQuery(UserName, Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()), dtSourceInterim.Rows[i]["問題"].ToString().Trim(), dtSourceInterim.Rows[i]["分類"].ToString(), dtSourceInterim.Rows[i]["使用中"].ToString(), dtSourceInterim.Rows[i]["全體共用"].ToString());
            }
            tempRow = dtOriginalTable.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.DELETED.ToString()).OrderBy(y => y["ID"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOriginalTable.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                try
                {
                    adapterQuestion.DeleteQuery(Convert.ToInt16(dtSourceInterim.Rows[i]["ID"].ToString()));
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 547:
                            ShowError("ID:" + dtSourceInterim.Rows[i]["ID"].ToString().Trim() + dtSourceInterim.Rows[i]["NAME"].ToString().Trim() + " 已連結至其他資料，不可刪除");
                            break;
                        default:
                            ShowError(401);
                            break;
                    }
                }
            }
            dtQuestionSource = adapterQuestion.GetData();
            gvQuestion.DataSource = dtQuestionSource;
            tbcManagement.Enabled = true;
            questionTabMode = FunctionMode.STATIC;
            txtQuestionTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
            LoadControlStatus(currentTabPage);
        }

        #region 導向問題分配
        //Right click to show menu for 問題分配 section
        private void gvQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = gvQuestion.HitTest(e.X, e.Y);
                gvQuestion.ClearSelection();
                gvQuestion.CurrentCell = gvQuestion.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                gvQuestion.Rows[hit.RowIndex].Selected = true;
            }
        }
        private void tsmQuestionAssignment_Click(object sender, EventArgs e)
        {
            if (questionTabMode != FunctionMode.STATIC)
            {
                txtQuestionTabMemo.Text += "錯誤:分配問題前，請先離開問題編輯模式(儲存或取消變更)" + Environment.NewLine;
            }
            else
            {
                tbcManagement.SelectedTab = tbpQuestionAssignment;
                questionAssignmentTabMode = FunctionMode.EDIT;
                LoadControlStatus(currentTabPage);
                LoadQuestionAssignment();
            }
        }

        #endregion
        #endregion

        /*
         * 問題分配跟其他TAB的差別在於，問題分配是由right click on問題建立中的問題進入的，而非直接選取TAB
         */
        #region 問題分配 Tab Methods and Events
        private void LoadQuestionAssignment()
        {
            lblQuestionAssignmentQuestionID.Text = gvQuestion.CurrentRow.Cells["ID"].FormattedValue.ToString();
            lblQuestionAssignmentQuestionCategory.Text = gvQuestion.CurrentRow.Cells["分類"].FormattedValue.ToString();
            if ((bool)gvQuestion.CurrentRow.Cells["使用中"].FormattedValue)
            {
                txtQuestionAssignmentQuestionBody.Text = "";
            }
            else
            {
                txtQuestionAssignmentQuestionBody.Text = "(此問題目前未被使用)" + Environment.NewLine;
            }
            if ((bool)gvQuestion.CurrentRow.Cells["全體共用"].FormattedValue)
            {
                txtQuestionAssignmentQuestionBody.Text += "(此問題為全體共用，無須另外分配)" + Environment.NewLine;
            }
            txtQuestionAssignmentQuestionBody.Text += gvQuestion.CurrentRow.Cells["問題"].FormattedValue.ToString();
            //Load listview
            LoadQuestionAssignmentDeptListView();
            LoadQuestionAssignmentEmpListView();
            //Load combobox     
            LoadcbxQuestionAssignmentDept();
            LoadcbxQuestionAssignmentEmp();
            if (cbxQuestionAssignmentDept.Items.Count > 0)
            {
                btnQuestionAssignmentAddDept.Enabled = true;
                cbxQuestionAssignmentDept.SelectedIndex = 0;
            }
            else
            {
                btnQuestionAssignmentAddDept.Enabled = false;
            }
            if (cbxQuestionAssignmentEmp.Items.Count > 0)
            {
                btnQuestionAssignmentAddEmp.Enabled = true;
                cbxQuestionAssignmentEmp.SelectedIndex = 0;
            }
            else
            {
                btnQuestionAssignmentAddEmp.Enabled = false;
            }
        }
        private void LoadQuestionAssignmentDeptListView()
        {
            Dictionary<string, string> dictQuestionAssignmentDept = new Dictionary<string, string>();
            lvQuestionAssignmentDept.Clear();
            dictQuestionAssignmentDept = GetCurrentDeptList();
            foreach (KeyValuePair<string, string> kvp in dictQuestionAssignmentDept)
            {
                lvQuestionAssignmentDept.Items.Add(kvp.Key + " " + kvp.Value);
            }
        }
        private Dictionary<string, string> GetCurrentDeptList()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT ASSIGN.QUESTION_ID, LTRIM(RTRIM(ASSIGN.DEPT)) 'DEPT_ID', LTRIM(RTRIM(ME.ME002)) 'DEPT_NAME'"
                            + " FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A ASSIGN"
                            + " LEFT JOIN NZ.dbo.CMSME ME ON ASSIGN.DEPT=ME.ME001"
                            + " WHERE QUESTION_ID=@QUESTION_ID"
                            + " ORDER BY ASSIGN.DEPT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@QUESTION_ID", Convert.ToInt16(gvQuestion.CurrentRow.Cells["ID"].FormattedValue));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!string.IsNullOrWhiteSpace(dr.GetString(1)))
                            {
                                string keyVal = dr.GetString(1);
                                string valVal = dr.GetString(2);
                                returnDict.Add(keyVal, valVal);
                            }
                        }
                    }
                }
            }
            return returnDict;
        }
        private void LoadQuestionAssignmentEmpListView()
        {
            Dictionary<string, string> dictQuestionAssignmentEmp = new Dictionary<string, string>();
            lvQuestionAssignmentEmp.Clear();
            dictQuestionAssignmentEmp = GetCurrentEmpList();
            foreach (KeyValuePair<string, string> kvp in dictQuestionAssignmentEmp)
            {
                lvQuestionAssignmentEmp.Items.Add(kvp.Key + " " + kvp.Value);
            }
        }
        private Dictionary<string, string> GetCurrentEmpList()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT ASSIGN.QUESTION_ID, LTRIM(RTRIM(ASSIGN.EMP_ID)) 'EMP_ID', LTRIM(RTRIM(MV.MV002)) 'EMP_NAME'"
                            + " FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A ASSIGN"
                            + " LEFT JOIN NZ.dbo.CMSMV MV ON ASSIGN.EMP_ID=MV.MV001"
                            + " WHERE QUESTION_ID=@QUESTION_ID"
                            + " AND MV.MV022=''"
                            + " ORDER BY ASSIGN.EMP_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@QUESTION_ID", Convert.ToInt16(gvQuestion.CurrentRow.Cells["ID"].FormattedValue));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!string.IsNullOrWhiteSpace(dr.GetString(1)))
                            {
                                string keyVal = dr.GetString(1);
                                string valVal = dr.GetString(2);
                                returnDict.Add(keyVal, valVal);
                            }
                        }
                    }
                }
            }
            return returnDict;
        }
        private void LoadcbxQuestionAssignmentDept()
        {
            Dictionary<string, string> dictFullDeptList = new Dictionary<string, string>();
            Dictionary<string, string> dictcbxQuestionAssignmentDeptSource = new Dictionary<string, string>();
            cbxQuestionAssignmentDept.Items.Clear();
            dictFullDeptList = GetFullDeptList();
            dictcbxQuestionAssignmentDeptSource = RemoveItemsInListViewFromDictionary(dictFullDeptList, lvQuestionAssignmentDept);
            foreach (KeyValuePair<string, string> kvp in dictcbxQuestionAssignmentDeptSource)
            {
                cbxQuestionAssignmentDept.Items.Add(kvp.Key + " " + kvp.Value);
            }
        }
        private Dictionary<string, string> GetFullDeptList()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(ME.ME001)) 'DEPT_ID', LTRIM(RTRIM(ME.ME002)) 'DEPT_NAME'"
                            + " FROM CMSME ME"
                            + " ORDER BY ME.ME001";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string keyVal = dr.GetString(0);
                            string valVal = dr.GetString(1);
                            returnDict.Add(keyVal, valVal);
                        }
                    }
                }
            }
            return returnDict;
        }
        private void LoadcbxQuestionAssignmentEmp()
        {
            Dictionary<string, string> dictFullEmpList = new Dictionary<string, string>();
            Dictionary<string, string> dictcbxQuestionAssignmentEmpSource = new Dictionary<string, string>();
            cbxQuestionAssignmentEmp.Items.Clear();
            dictFullEmpList = GetFullEmpList();
            dictcbxQuestionAssignmentEmpSource = RemoveItemsInListViewFromDictionary(dictFullEmpList, lvQuestionAssignmentEmp);
            foreach (KeyValuePair<string, string> kvp in dictcbxQuestionAssignmentEmpSource)
            {
                cbxQuestionAssignmentEmp.Items.Add(kvp.Key + " " + kvp.Value);
            }
        }
        private Dictionary<string, string> GetFullEmpList()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(MV.MV001)) 'EMP_ID', LTRIM(RTRIM(MV.MV002)) 'EMP_NAME'"
                            + " FROM CMSMV MV"
                            + " WHERE MV.MV022=''"
                            + " AND MV.MV001 <> '0000'"
                            + " AND MV.MV001 <> '0098'"
                            + " AND MV.MV001 NOT LIKE 'PT%'"
                            + " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                //load all emp
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string keyVal = dr.GetString(0);
                        string valVal = dr.GetString(1);
                        returnDict.Add(keyVal, valVal);
                    }
                }
            }
            return returnDict;
        }
        private string[] SplitString(string s, string[] stringSeparators)
        {
            string[] returnStringArray;
            returnStringArray = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            return returnStringArray;
        }
        private Dictionary<string, string> GetItemsFromListView(ListView lv)
        {
            Dictionary<string, string> returnValue = new Dictionary<string, string>();
            foreach (ListViewItem lvi in lv.Items)
            {
                string[] tempStringArray;
                tempStringArray = SplitString(lvi.Text, new string[] { " " });
                returnValue.Add(tempStringArray[0], tempStringArray[1]);
            }
            return returnValue;
        }
        /// <summary>
        /// Remove Items in ListView from Dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="lv"></param>
        /// <returns></returns>
        private Dictionary<string, string> RemoveItemsInListViewFromDictionary(Dictionary<string, string> dict, ListView lv)
        {
            Dictionary<string, string> remove = GetItemsFromListView(lv);
            foreach (KeyValuePair<string, string> kvp in remove)
            {
                if (dict.ContainsKey(kvp.Key))
                {
                    dict.Remove(kvp.Key);
                }
            }
            return dict;
        }

        private void btnQuestionAssignmentAddDept_Click(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            string[] tempStringArray;
            if (cbxQuestionAssignmentDept.Items.Count > 0)
            {
                selectedIndex = cbxQuestionAssignmentDept.SelectedIndex;
                tempStringArray = SplitString(cbxQuestionAssignmentDept.Text, new string[] { " " });
                lvQuestionAssignmentDept.Items.Add(tempStringArray[0] + " " + tempStringArray[1]);
                cbxQuestionAssignmentDept.Items.RemoveAt(selectedIndex);
            }
            if (cbxQuestionAssignmentDept.Items.Count > 0 && selectedIndex < cbxQuestionAssignmentDept.Items.Count)
            {
                cbxQuestionAssignmentDept.SelectedIndex = selectedIndex;
            }
            else if (cbxQuestionAssignmentDept.Items.Count > 0 && selectedIndex >= cbxQuestionAssignmentDept.Items.Count)
            {
                cbxQuestionAssignmentDept.SelectedIndex = cbxQuestionAssignmentDept.Items.Count - 1;
            }
        }
        private void btnQuestionAssignmentRemoveDept_Click(object sender, EventArgs e)
        {
            if (lvQuestionAssignmentDept.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvQuestionAssignmentDept.SelectedItems)
                {
                    cbxQuestionAssignmentDept.Items.Add(item.Text);
                    lvQuestionAssignmentDept.Items.Remove(item);
                }
            }
            if (cbxQuestionAssignmentDept.Items.Count > 0)
            {
                cbxQuestionAssignmentDept.SelectedIndex = 0;
            }
        }

        private void btnQuestionAssignmentAddEmp_Click(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            string[] tempStringArray;
            if (cbxQuestionAssignmentEmp.Items.Count > 0)
            {
                selectedIndex = cbxQuestionAssignmentEmp.SelectedIndex;
                tempStringArray = SplitString(cbxQuestionAssignmentEmp.Text, new string[] { " " });
                lvQuestionAssignmentEmp.Items.Add(tempStringArray[0] + " " + tempStringArray[1]);
                cbxQuestionAssignmentEmp.Items.RemoveAt(selectedIndex);
            }
            if (cbxQuestionAssignmentEmp.Items.Count > 0 && selectedIndex < cbxQuestionAssignmentEmp.Items.Count)
            {
                cbxQuestionAssignmentEmp.SelectedIndex = selectedIndex;
            }
            else if (cbxQuestionAssignmentEmp.Items.Count > 0 && selectedIndex >= cbxQuestionAssignmentEmp.Items.Count)
            {
                cbxQuestionAssignmentEmp.SelectedIndex = cbxQuestionAssignmentEmp.Items.Count - 1;
            }
        }

        private void btnQuestionAssignmentRemoveEmp_Click(object sender, EventArgs e)
        {
            if (lvQuestionAssignmentEmp.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvQuestionAssignmentEmp.SelectedItems)
                {
                    cbxQuestionAssignmentEmp.Items.Add(item.Text);
                    lvQuestionAssignmentEmp.Items.Remove(item);
                }
            }
            if (cbxQuestionAssignmentEmp.Items.Count > 0)
            {
                cbxQuestionAssignmentEmp.SelectedIndex = 0;
            }
        }
        private void btnQuestionAssignmentCancel_Click(object sender, EventArgs e)
        {
            LoadQuestionAssignment();
            questionAssignmentTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            txtQuestionAssignmentTabMemo.Text += DateTime.Now.ToString() + " 問題" + lblQuestionAssignmentQuestionID.Text + "資料更新取消" + Environment.NewLine;
        }

        private void btnQuestionAssignmentSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dictDeptInListView = new Dictionary<string, string>();
            Dictionary<string, string> dictEmpInListView = new Dictionary<string, string>();
            Dictionary<string, string> dictDeptNotInList = new Dictionary<string, string>();
            Dictionary<string, string> dictEmpNotInList = new Dictionary<string, string>();

            dictDeptInListView = GetItemsFromListView(lvQuestionAssignmentDept);
            dictDeptNotInList = GetFullDeptList();
            foreach (KeyValuePair<string, string> kvp in dictDeptInListView)
            {
                dictDeptNotInList.Remove(kvp.Key);
            }
            dictEmpInListView = GetItemsFromListView(lvQuestionAssignmentEmp);
            dictEmpNotInList = GetFullEmpList();
            foreach (KeyValuePair<string, string> kvp in dictEmpInListView)
            {
                dictEmpNotInList.Remove(kvp.Key);
            }

            foreach (KeyValuePair<string, string> kvp in dictDeptNotInList)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " WHERE QUESTION_ID=@ID"
                                + " AND DEPT=@DEPT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                    cmd.Parameters.AddWithValue("@DEPT", kvp.Key);
                    cmd.ExecuteNonQuery();
                }
            }
            foreach (KeyValuePair<string, string> kvp in dictEmpNotInList)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " WHERE QUESTION_ID=@ID"
                                + " AND EMP_ID=@EMP";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                    cmd.Parameters.AddWithValue("@EMP", kvp.Key);
                    cmd.ExecuteNonQuery();
                }
            }

            foreach (KeyValuePair<string, string> kvp in dictDeptInListView)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT QUESTION_ID, DEPT"
                                + " FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " WHERE QUESTION_ID=@ID"
                                + " AND DEPT=@DEPT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                    cmd.Parameters.AddWithValue("@DEPT", kvp.Key);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.HasRows)
                        {
                            query = "INSERT INTO HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " VALUES"
                                + " (GETDATE(), @USERNAME, GETDATE(), @USERNAME, @ID, @DEPT, '')";
                            SqlCommand cmdInsert = new SqlCommand(query, conn);
                            cmdInsert.Parameters.AddWithValue("@USERNAME", UserName);
                            cmdInsert.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                            cmdInsert.Parameters.AddWithValue("@DEPT", kvp.Key);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, string> kvp in dictEmpInListView)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT QUESTION_ID, EMP_ID"
                                + " FROM HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " WHERE QUESTION_ID=@ID"
                                + " AND EMP_ID=@EMP";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                    cmd.Parameters.AddWithValue("@EMP", kvp.Key);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.HasRows)
                        {
                            query = "INSERT INTO HR360_ASSESSMENTQUESTION_ASSIGNMENT_A"
                                + " VALUES"
                                + " (GETDATE(), @USERNAME, GETDATE(), @USERNAME, @ID, '', @EMP)";
                            SqlCommand cmdInsert = new SqlCommand(query, conn);
                            cmdInsert.Parameters.AddWithValue("@USERNAME", UserName);
                            cmdInsert.Parameters.AddWithValue("@ID", lblQuestionAssignmentQuestionID.Text);
                            cmdInsert.Parameters.AddWithValue("@EMP", kvp.Key);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
            txtQuestionAssignmentTabMemo.Text += DateTime.Now.ToString() + " 問題" + lblQuestionAssignmentQuestionID.Text + "資料更新完成" + Environment.NewLine;
            questionAssignmentTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);

        }
        #endregion

        #region 評分權重設定 Tab Methods and Events
        private void DisplayScoreWeightData(int year)
        {
            DataTable dt = new DataTable();
            dt = GetScoreWeight(year);

            foreach (DataRow row in dt.Rows)
            {
                if (row["assessType"].ToString() == "1")
                {
                    txtSetScoreWeightSelfWeight.Text = String.IsNullOrWhiteSpace(row["scoreWeight"].ToString()) ? "" : row["scoreWeight"].ToString();
                }
                else if (row["assessType"].ToString() == "2")
                {
                    txtSetScoreWeightSupervisorWeight.Text = String.IsNullOrWhiteSpace(row["scoreWeight"].ToString()) ? "" : row["scoreWeight"].ToString();
                }
                else if (row["assessType"].ToString() == "3")
                {
                    txtSetScoreWeightFinalizerWeight.Text = String.IsNullOrWhiteSpace(row["scoreWeight"].ToString()) ? "" : row["scoreWeight"].ToString();
                }
            }
        }
        //private DataTable LoadScoreWeightData(int year)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        //    {
        //        conn.Open();
        //        string query = "Select selfEvaluationWeight, supervisorEvaluationWeight, finalizerEvaluationWeight"
        //            + " From HR360_AssessmentPersonnel_ScoreWeight"
        //            + " Where assessYear = @Year";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@Year", year);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //    }
        //    return dt;
        //}
        private void btnSetScoreWeightEdit_Click(object sender, EventArgs e)
        {
            setScoreWeightTabMode = FunctionMode.EDIT;
            LoadControlStatus(tbpSetScoreWeight);
        }
        private void cbxSetScoreWeightYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayScoreWeightData(Convert.ToInt32(cbxSetScoreWeightYear.Text));
            LoadControlStatus(tbpSetScoreWeight);
        }
        private void btnSetScoreWeightSave_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (!Int32.TryParse(txtSetScoreWeightFinalizerWeight.Text, out temp) ||
                !Int32.TryParse(txtSetScoreWeightSupervisorWeight.Text, out temp) ||
                !Int32.TryParse(txtSetScoreWeightSelfWeight.Text, out temp))
            {
                ShowError(102);
            }
            else if (Int32.Parse(txtSetScoreWeightFinalizerWeight.Text) +
                Int32.Parse(txtSetScoreWeightSupervisorWeight.Text) +
                Int32.Parse(txtSetScoreWeightSelfWeight.Text) != 100)
            {
                ShowError(999);
            }
            else
            {
                for (int i = 1; i <= 3; i++)    //評核UID 1-3 自評、主管評、評核主管評
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();

                        string query = "update HR360_AssessmentCategory_CategoryWeight" +
                            " set modifiedDate=@date" +
                            " ,modifier=@user" +
                            " ,scoreWeight=@scoreWeight" +
                            " where assessYear=@assessYear" +
                            " and assessType=@assessType" +
                            " if @@ROWCOUNT=0" +
                            " insert into HR360_AssessmentCategory_CategoryWeight" +
                            " values (@date,@user,@date,@user,@assessYear,@assessType,@scoreWeight)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@user", UserName);
                        cmd.Parameters.AddWithValue("@assessYear", cbxSetScoreWeightYear.Text);
                        cmd.Parameters.AddWithValue("@assessType", i.ToString());
                        if (i == 1)
                        {
                            cmd.Parameters.AddWithValue("@scoreWeight", txtSetScoreWeightSelfWeight.Text.Trim());
                        }
                        else if (i == 2)
                        {
                            cmd.Parameters.AddWithValue("@scoreWeight", txtSetScoreWeightSupervisorWeight.Text.Trim());
                        }
                        else if (i == 3)
                        {
                            cmd.Parameters.AddWithValue("@scoreWeight", txtSetScoreWeightFinalizerWeight.Text.Trim());
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                txtSetScoreWeightMemo.Text += DateTime.Now + " " + cbxSetScoreWeightYear.Text + "年資料更新完成" + Environment.NewLine;
                setScoreWeightTabMode = FunctionMode.STATIC;
                LoadControlStatus(tbpSetScoreWeight);
            }
        }
        private void btnSetScoreWeightCancel_Click(object sender, EventArgs e)
        {
            txtSetScoreWeightMemo.Text += DateTime.Now + " " + cbxSetScoreWeightYear.Text + "年資料更新取消" + Environment.NewLine;
            setScoreWeightTabMode = FunctionMode.STATIC;
            LoadControlStatus(tbpSetScoreWeight);
        }
        #endregion



        #region 評核設定主管人數設定 Tab Method and Events
        private void DisplaySetSupervisorAmountData(int year)
        {
            LoadSetSupervisorAmountData(year);
            gvSetSupervisorAmountInputField.DataSource = dtSetSupervisorAmountSource;
            LoadGridViewStyle(gvSetSupervisorAmountInputField);
        }

        private void LoadSetSupervisorAmountData(int year)
        {
            dtSetSupervisorAmountSource = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "select COALESCE(ap.assessYear,(@year)) [評核年份]" +
                    " ,LTRIM(RTRIM(MV.MV001)) [員工ID]" +
                    " ,MV.MV002 [員工姓名]" +
                    " ,COALESCE(CONVERT(NVARCHAR(10),ap.assessorSupervisorAmount), '') [評核主管人數]" +
                    " ,COALESCE(CONVERT(NVARCHAR(10),ap.assessorFinalizerAmount), '1') [核決主管人數]" + //核決主管人數固定為1人
                    " from HR360_AssessmentPersonnel_Assignment_B ap" +
                    " right join NZ.dbo.CMSMV MV ON ap.assessedID=MV.MV001 and ap.assessYear=@year" +
                    " where (MV.MV001 not like 'PT%'" +
                    " AND MV.MV001<>'0000'" +
                    " AND MV.MV001<>'0006'" +
                    " AND MV.MV001<>'0007'" +
                    " AND MV.MV001<>'0098'" +
                    " AND ((MV.MV021<=@year+'1231' AND MV.MV022='')" +
                    " OR (MV.MV021<=@year+'1231' AND MV.MV022>@year+'1231')))" +
                    " OR ap.[assessYear]=@year" +
                    " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSetSupervisorAmountSource);

            }
        }
        private void cbxSetSupervisorAmountYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doesAssignmentExist(cbxSetSupervisorAmountYear.SelectedItem.ToString()))
            {
                setSupervisorAmountTabMode = FunctionMode.DISABLED;
            }
            else
            {
                setSupervisorAmountTabMode = FunctionMode.STATIC;
            }
            LoadControlStatus(tbpSetSupervisorAmount);
        }

        private void btnSetSupervisorAmountEdit_Click(object sender, EventArgs e)
        {
            setSupervisorAmountTabMode = FunctionMode.EDIT;
            LoadControlStatus(tbpSetSupervisorAmount);
        }

        private void btnSetSupervisorAmountSave_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in gvSetSupervisorAmountInputField.Rows)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "update HR360_AssessmentPersonnel_Assignment_B" +
                        " set modifiedDate=@date" +
                        " ,modifier=@user" +
                        " ,assessorSupervisorAmount=@supervisorAmount" +
                        " ,assessorFinalizerAmount=@finalizerAmount" +
                        " where assessYear=@year" +
                        " and assessedID=@assessed" +
                        " if @@ROWCOUNT=0" +
                        " insert into HR360_AssessmentPersonnel_Assignment_B" +
                        " values (@date,@user,@date,@user,@year,@assessed,@supervisorAmount,@finalizerAmount)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@user", UserName);
                    cmd.Parameters.AddWithValue("@supervisorAmount", row.Cells["評核主管人數"].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@finalizerAmount", 1);
                    cmd.Parameters.AddWithValue("@year", row.Cells["評核年份"].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@assessed", row.Cells["員工ID"].FormattedValue.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            setSupervisorAmountTabMode = FunctionMode.STATIC;
            LoadControlStatus(tbpSetSupervisorAmount);
            txtSetSupervisorAmountMemo.Text = DateTime.Now.ToString() + " " + cbxSetSupervisorAmountYear.Text + "年資料更新完成" + Environment.NewLine;
        }

        private void btnSetSupervisorAmountCancel_Click(object sender, EventArgs e)
        {
            setSupervisorAmountTabMode = FunctionMode.STATIC;
            LoadControlStatus(tbpSetSupervisorAmount);
            txtSetSupervisorAmountMemo.Text = DateTime.Now.ToString() + " " + cbxSetSupervisorAmountYear.Text + "年資料更新取消" + Environment.NewLine;
        }

        private bool doesAssignmentExist(string year)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "select case" +
                    " when exists (select top 1 * from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A where [YEAR] = @year) then 1" +
                    " else 0" +
                    " end";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year);
                return Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar().ToString()));
            }
        }
        #endregion



        #region 評核人員分配 Tab Methods and Events
        /*這邊有個重點，自評的分配與調整將會自動於背景進行，以ERP中在職者為依據進行新增以及編輯(使已離職者INACTIVE)*/
        private void DisplayPersonnelAssignmentData(int year)
        {
            LoadgvPersonnelAssignment(year);
            gvPersonnelAssignment.DataSource = dtPersonnelAssignmentSource;
            LoadGridViewStyle(gvPersonnelAssignment);
        }

        private void LoadgvPersonnelAssignment(int year)
        {
            dtPersonnelAssignmentSource = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "";
                if (year < 2019)
                {
                    query = ";with assessorList as" +
                        " (" +
                        " SELECT COALESCE(ASSIGN.[YEAR], @YEAR) '年份'" +
                        " , LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'" +
                        " , COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)), LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002))) '評核者'" +
                        " , 0 '評核主管數量'" +
                        " , COALESCE([TYPE].[ID] + '. ' +[TYPE].NAME, (select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where [ID] = '1')) '評核類型'" +
                        " FROM NZ.dbo.CMSMV MV" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A ASSIGN ON MV.MV001 = ASSIGN.ASSESSED_ID AND ASSIGN.[YEAR]=@YEAR AND ASSIGN.ACTIVE='1' AND ASSIGN.ASSESS_TYPE='1'" +
                        " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID= MVASSESSOR.MV001" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A[TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID" +
                        " LEFT JOIN HR360_AssessmentPersonnel_Assignment_B ASSIGNSUPERVISOR ON MV.MV001= ASSIGNSUPERVISOR.assessedID AND ASSIGNSUPERVISOR.assessYear= @YEAR" +
                        " WHERE" +
                        " (MV.MV022= ''" +
                        " OR MV.MV022 > @YEAR+'1232')" +
                        " AND MV.MV021<@YEAR+'1232'" +
                        " AND MV.MV001 NOT LIKE 'PT%'" +
                        " AND MV.MV001<>'0000'" +
                        " AND MV.MV001<>'0006'" +
                        " AND MV.MV001<>'0007'" +
                        " AND MV.MV001<>'0098'" +
                        " union all" +
                        " SELECT COALESCE(ASSIGN.[YEAR], @YEAR) '年份'" +
                        " , LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'" +
                        " , COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)), '') '評核者'" +
                        " , COALESCE(Convert(int, ASSIGNSUPERVISOR.assessorSupervisorAmount) + Convert(int, ASSIGNSUPERVISOR.assessorFinalizerAmount), '0') '評核主管數量'" +
                        " , COALESCE([TYPE].[ID] + '. ' +[TYPE].NAME, '') '評核類型'" +
                        " FROM NZ.dbo.CMSMV MV" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A ASSIGN ON MV.MV001 = ASSIGN.ASSESSED_ID AND ASSIGN.[YEAR]= @YEAR AND ASSIGN.ACTIVE= '1'" +
                        " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID= MVASSESSOR.MV001" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A[TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID" +
                        " LEFT JOIN HR360_AssessmentPersonnel_Assignment_B ASSIGNSUPERVISOR ON MV.MV001= ASSIGNSUPERVISOR.assessedID AND ASSIGNSUPERVISOR.assessYear= @YEAR" +
                        " WHERE" +
                        " (MV.MV022= ''" +
                        " OR MV.MV022 > @YEAR+'1232')" +
                        " AND MV.MV021<@YEAR+'1232'" +
                        " AND MV.MV001 NOT LIKE 'PT%'" +
                        " AND MV.MV001<>'0000'" +
                        " AND MV.MV001<>'0006'" +
                        " AND MV.MV001<>'0007'" +
                        " AND MV.MV001<>'0098'" +
                        " union all" +
                        " select al.年份, al.受評者, al.評核者, (al.評核主管數量-1) 評核主管數量, al.評核類型" +
                        " from assessorList al" +
                        " where al.[評核主管數量] > 1" +
                        " )" +
                        " select distinct al.年份" +
                        " , al.受評者" +
                        " , al.評核者" +
                        " , al.評核主管數量 '評核順位'" +
                        " , case" +
                        " when al.評核類型<>'' then 評核類型" +
                        " else" +
                        " case" +
                        " when al.評核主管數量= 0 then 評核類型" +
                        " when al.評核主管數量= (select MAX(assessorList.評核主管數量) from assessorList where [年份]= @YEAR and[受評者]= al.受評者) then(select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where[ID]= '3')" +
                        " else (select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where[ID]='2')" +
                        " end" +
                        " end as 評核類型" +
                        " from assessorList al" +
                        " left join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assign on SUBSTRING(al.受評者,1,4)=assign.ASSESSED_ID and SUBSTRING(al.評核者,1,4)=assign.ASSESSOR_ID and al.年份=assign.[YEAR]" +
                        " order by 受評者, 評核類型, 評核順位";
                }
                else
                {
                    query = ";with floatingAssessorList as" +
                        " (" +
                        " SELECT COALESCE(ASSIGN.[YEAR], @YEAR) '年份'" +
                        " , LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'" +
                        " , COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)), '') '評核者'" +
                        " , COALESCE(ASSIGN.ASSESSOR_ORDER, ASSIGNSUPERVISOR.assessorSupervisorAmount) '評核主管數量'" +
                        " , COALESCE([TYPE].[ID] + '. ' +[TYPE].NAME, '') '評核類型'" +
                        " FROM NZ.dbo.CMSMV MV" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A ASSIGN ON MV.MV001 = ASSIGN.ASSESSED_ID AND ASSIGN.[YEAR]= @YEAR AND ASSIGN.ACTIVE= '1' AND ASSIGN.ASSESS_TYPE= '2'" +
                        " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID= MVASSESSOR.MV001" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A[TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID" +
                        " LEFT JOIN HR360_AssessmentPersonnel_Assignment_B ASSIGNSUPERVISOR ON MV.MV001= ASSIGNSUPERVISOR.assessedID AND ASSIGNSUPERVISOR.assessYear= @YEAR" +
                        " WHERE" +
                        " (MV.MV022= ''" +
                        " OR MV.MV022 > @YEAR+'1232')" +
                        " AND MV.MV021<@YEAR+'1232'" +
                        " AND MV.MV001 NOT LIKE 'PT%'" +
                        " AND MV.MV001<>'0000'" +
                        " AND MV.MV001<>'0006'" +
                        " AND MV.MV001<>'0007'" +
                        " AND MV.MV001<>'0098'" +
                        " and COALESCE(ASSIGN.ASSESSOR_ORDER, ASSIGNSUPERVISOR.assessorSupervisorAmount)>0" +
                        " union all" +
                        " select al.年份, al.受評者, al.評核者, (al.評核主管數量-1) 評核主管數量, al.評核類型" +
                        " from floatingAssessorList al" +
                        " where al.[評核主管數量] > 1 and al.評核類型= ''" +
                        " )," +
                        " fixedAssessorList as" +
                        " (SELECT COALESCE(ASSIGN.[YEAR], @YEAR) '年份'" +
                        " , LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'" +
                        " , COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)), LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002))) '評核者'" +
                        " , 0 '評核主管數量'" +
                        " , COALESCE([TYPE].[ID] + '. ' +[TYPE].NAME, (select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where[ID] = '1')) '評核類型'" +
                        " FROM NZ.dbo.CMSMV MV" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A ASSIGN ON MV.MV001 = ASSIGN.ASSESSED_ID AND ASSIGN.[YEAR]= @YEAR AND ASSIGN.ACTIVE= '1' AND ASSIGN.ASSESS_TYPE= '1'" +
                        " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID= MVASSESSOR.MV001" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A[TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID" +
                        " WHERE" +
                        " (MV.MV022= ''" +
                        " OR MV.MV022 > @YEAR+'1232')" +
                        " AND MV.MV021<@YEAR+'1232'" +
                        " AND MV.MV001 NOT LIKE 'PT%'" +
                        " AND MV.MV001<>'0000'" +
                        " AND MV.MV001<>'0006'" +
                        " AND MV.MV001<>'0007'" +
                        " AND MV.MV001<>'0098'" +
                        " union all" +
                        " SELECT COALESCE(ASSIGN.[YEAR], @YEAR) '年份'" +
                        " , LTRIM(RTRIM(MV.MV001)) + ' ' + LTRIM(RTRIM(MV.MV002)) '受評者'" +
                        " , COALESCE(LTRIM(RTRIM(ASSIGN.ASSESSOR_ID)) + ' ' + LTRIM(RTRIM(MVASSESSOR.MV002)), '') '評核者'" +
                        " , COALESCE(Convert(int, ASSIGNSUPERVISOR.assessorSupervisorAmount) + Convert(int, ASSIGNSUPERVISOR.assessorFinalizerAmount), '0') '評核主管數量'" +
                        " , COALESCE([TYPE].[ID] + '. ' +[TYPE].NAME, (select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where[ID] = '3')) '評核類型'" +
                        " FROM NZ.dbo.CMSMV MV" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A ASSIGN ON MV.MV001 = ASSIGN.ASSESSED_ID AND ASSIGN.[YEAR]= @YEAR AND ASSIGN.ACTIVE= '1' AND ASSIGN.ASSESS_TYPE= '3'" +
                        " LEFT JOIN NZ.dbo.CMSMV MVASSESSOR ON ASSIGN.ASSESSOR_ID= MVASSESSOR.MV001" +
                        " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A[TYPE] ON ASSIGN.ASSESS_TYPE=[TYPE].ID" +
                        " LEFT JOIN HR360_AssessmentPersonnel_Assignment_B ASSIGNSUPERVISOR ON MV.MV001= ASSIGNSUPERVISOR.assessedID AND ASSIGNSUPERVISOR.assessYear= @YEAR" +
                        " WHERE" +
                        " (MV.MV022= ''" +
                        " OR MV.MV022 > @YEAR+'1232')" +
                        " AND MV.MV021<@YEAR+'1232'" +
                        " AND MV.MV001 NOT LIKE 'PT%'" +
                        " AND MV.MV001<>'0000'" +
                        " AND MV.MV001<>'0006'" +
                        " AND MV.MV001<>'0007'" +
                        " AND MV.MV001<>'0098'" +
                        " )," +
                        " assessorList as" +
                        " (" +
                        " select fal.年份,fal.受評者,fal.評核者,fal.評核主管數量,fal.評核類型" +
                        " from floatingAssessorList fal" +
                        " left join HR360_AssessmentPersonnel_Assignment_B assignB on fal.年份=assignB.assessYear and substring(fal.受評者,1,4)=assignB.assessedID" +
                        " where 評核主管數量 < Convert(int,assignB.assessorSupervisorAmount)+Convert(int,assignB.assessorFinalizerAmount)" +
                        " union all" +
                        " select*" +
                        " from fixedAssessorList" +
                        " )" +
                        " select 年份" +
                        " ,受評者" +
                        " ,評核者" +
                        " ,評核主管數量 '評核順位'" +
                        " ,case" +
                        " when 評核類型 = '' then(select[ID] + '. ' + [NAME] from HR360_ASSESSMENTPERSONNEL_TYPE_A where[ID]= '2')" +
                        " else 評核類型" +
                        " end " +
                        " as '評核類型'" +
                        " from assessorList" +
                        " order by 受評者,評核主管數量";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", year.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtPersonnelAssignmentSource);
            }
        }

        private void cbxPersonnelAssignmentYear_SelectedIndexChanged(object sender, EventArgs e)
        {            
            LoadControlStatus(tbpPersonnelAssignment);
        }

        private void btnPersonnelAssignmentEdit_Click(object sender, EventArgs e)
        {
            personnelAssignmentTabMode = FunctionMode.EDIT;
            LoadControlStatus(currentTabPage);
            if (gvPersonnelAssignment.Rows.Count > 0)
            {
                gvQuestionCategory.CurrentCell = gvQuestionCategory.Rows[0].Cells[0];
            }
        }

        private void btnPersonnelAssignmentClearData_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("確定要刪除" + cbxPersonnelAssignmentYear.SelectedItem + "年的評核人員分配資料嗎?", "刪除確認", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "delete from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                        " where [YEAR] = @year";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@year", cbxPersonnelAssignmentYear.SelectedItem);
                    cmd.ExecuteNonQuery();
                }
                txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " " + cbxPersonnelAssignmentYear.SelectedItem + "年的評核人員分配資料已刪除" + Environment.NewLine;
            }
            personnelAssignmentTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
        }

        private void btnPersonnelAssignmentCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            personnelAssignmentTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
            isCancel = false;
        }
        private void btnPersonnelAssignmentSave_Click(object sender, EventArgs e)
        {
            UpdatePersonnelAssignment();
            personnelAssignmentTabMode = FunctionMode.STATIC;
            LoadControlStatus(currentTabPage);
            txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
        }
        private void UpdatePersonnelAssignment()
        {
            //DataTable dtEmployeeLeftThisYear = new DataTable();
            //Set all records in that year to inactive
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                            + " SET ACTIVE='0'"
                            + " WHERE [YEAR]=@YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", cbxPersonnelAssignmentYear.Text);
            }
            //Check each row for duplicate record
            
            foreach(DataGridViewRow row in gvPersonnelAssignment.Rows)
            {
                if (!String.IsNullOrWhiteSpace(row.Cells["評核者"].FormattedValue.ToString()))
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        /*
                         * 更新評核人員，如無資料，則新增
                         */
                        string query = "update HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                            " set [MODIFIEDDATE]=@date" +
                            " ,[MODIFIER]=@user" +
                            " ,[ASSESSOR_ID]=@assessorId" +
                            " ,[ACTIVE]=@active" +
                            " where [YEAR]=@year" +
                            " and [ASSESSOR_ORDER]=@assessorOrder" +
                            " and [ASSESSED_ID]=@assessedId" +
                            " and [ASSESS_TYPE]=@assessType" +
                            " if @@ROWCOUNT=0" +
                            " insert into HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                            " values (@date,@user,@date,@user,@year,@assessorOrder,@assessorId,@assessedId,@assessType,@assessmentDone,@active)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@user", UserName);
                        cmd.Parameters.AddWithValue("@assessorId", row.Cells["評核者"].FormattedValue.ToString().Substring(0, 4));
                        cmd.Parameters.AddWithValue("@active", '1');
                        cmd.Parameters.AddWithValue("@year", row.Cells["年份"].FormattedValue.ToString());
                        cmd.Parameters.AddWithValue("@assessorOrder", Convert.ToInt32(row.Cells["評核順位"].FormattedValue.ToString()));
                        cmd.Parameters.AddWithValue("@assessedId", row.Cells["受評者"].FormattedValue.ToString().Substring(0, 4));
                        cmd.Parameters.AddWithValue("@assessType", row.Cells["評核類型"].FormattedValue.ToString().Substring(0, 1));
                        cmd.Parameters.AddWithValue("@assessmentDone", '0');
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    txtPersonnelAssignmentTabMemo.Text += "Warning: [" + row.Cells["受評者"].FormattedValue.ToString() + "] 評核順位[" + row.Cells["評核順位"].FormattedValue.ToString() + "]尚未配置評核者" + Environment.NewLine;
                }
            }
            //int dataCount = 0;
            //foreach (DataGridViewRow row in gvPersonnelAssignment.Rows)
            //{
            //    dataCount++;
            //    txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 對比資料中...(" + dataCount.ToString() + "/" + gvPersonnelAssignment.Rows.Count + ")" + Environment.NewLine;
            //    if (!String.IsNullOrWhiteSpace(row.Cells["評核者"].FormattedValue.ToString()))
            //    {
            //        DataTable dtAssessedPairings = new DataTable();
            //        //Get all pairings of the assessed currently in database
            //        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //        {
            //            conn.Open();
            //            string query = "SELECT [YEAR],ASSESSOR_ID,ASSESSED_ID,ASSESS_TYPE,ACTIVE"
            //                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                        + " WHERE [YEAR]=@YEAR"
            //                        + " AND ASSESSED_ID=@ASSESSED_ID"
            //                        + " AND ASSESS_TYPE=@ASSESS_TYPE";
            //            SqlCommand cmd = new SqlCommand(query, conn);
            //            cmd.Parameters.AddWithValue("@YEAR", row.Cells["年份"].FormattedValue.ToString());
            //            cmd.Parameters.AddWithValue("@ASSESSED_ID", row.Cells["受評者"].FormattedValue.ToString().Substring(0, 4));
            //            cmd.Parameters.AddWithValue("@ASSESS_TYPE", row.Cells["評核類型"].FormattedValue.ToString().Substring(0, 1));
            //            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //            da.Fill(dtAssessedPairings);
            //        }
            //        if (dtAssessedPairings.Rows.Count == 1) //Each type of assessment for each assessed should only return 1 result
            //        {
            //            if (dtAssessedPairings.Rows[0]["ASSESS_TYPE"].ToString() == "2")    //主管評類型，檢查評核者是否相同
            //            {
            //                //Check if a 自評 for this 受評者 exists
            //                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //                {
            //                    conn.Open();
            //                    string query = "SELECT *"
            //                                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                                + " WHERE [YEAR]=@YEAR"
            //                                + " AND ASSESSED_ID=@ASSESSED_ID"
            //                                + " AND ASSESS_TYPE='1'";
            //                    SqlCommand cmd = new SqlCommand(query, conn);
            //                    cmd.Parameters.AddWithValue("@YEAR", dtAssessedPairings.Rows[0]["YEAR"].ToString());
            //                    cmd.Parameters.AddWithValue("@ASSESSED_ID", dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim());
            //                    using (SqlDataReader dr = cmd.ExecuteReader())
            //                    {
            //                        while (dr.Read())
            //                        {
            //                            if (!dr.HasRows)    //這個受評者沒有自評，須新增
            //                            {
            //                                query = "INSERT INTO HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                                    + " VALUES"
            //                                    + " (GETDATE(),@USER,GETDATE(),@USER,@YEAR,@ASSESSED_ID,@ASSESSED_ID,'1','0','1')";
            //                                cmd = new SqlCommand(query, conn);
            //                                cmd.Parameters.AddWithValue("@USER", UserName);
            //                                cmd.Parameters.AddWithValue("@YEAR", dtAssessedPairings.Rows[0]["YEAR"].ToString());
            //                                cmd.Parameters.AddWithValue("@ASSESSED_ID", dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim());
            //                                cmd.ExecuteNonQuery();
            //                                txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 新增加" + dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim() + "自評" + Environment.NewLine;
            //                            }
            //                        }
            //                    }
            //                }
            //                //Check if record in the gridview match record in database for this 受評者
            //                if (dtAssessedPairings.Rows[0]["ASSESSOR_ID"].ToString().Trim() == row.Cells["評核者"].FormattedValue.ToString().Substring(0, 4))
            //                {
            //                    //Setting record to Active without changing anything else
            //                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //                    {
            //                        conn.Open();
            //                        string query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                                    + " SET ACTIVE='1'"
            //                                    + " WHERE [YEAR]=@YEAR"
            //                                    + " AND ASSESSED_ID=@ASSESSED_ID"
            //                                    + " AND ASSESS_TYPE=@ASSESS_TYPE";
            //                        SqlCommand cmd = new SqlCommand(query, conn);
            //                        cmd.Parameters.AddWithValue("@YEAR", dtAssessedPairings.Rows[0]["YEAR"].ToString());
            //                        cmd.Parameters.AddWithValue("@ASSESSED_ID", dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim());
            //                        cmd.Parameters.AddWithValue("@ASSESS_TYPE", dtAssessedPairings.Rows[0]["ASSESS_TYPE"].ToString().Trim());
            //                        cmd.ExecuteNonQuery();
            //                    }
            //                }
            //                else
            //                {
            //                    //Modify record's Assessor and set it to Active
            //                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //                    {
            //                        conn.Open();
            //                        string query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                                    + " SET MODIFIEDDATE=GETDATE()"
            //                                    + " ,MODIFIER=@MODIFIER"
            //                                    + " ,ASSESSOR_ID=@ASSESSOR_ID"
            //                                    + " ,ASSESSMENT_DONE='0'"
            //                                    + " ,ACTIVE='1'"
            //                                    + " WHERE [YEAR]=@YEAR"
            //                                    + " AND ASSESSED_ID=@ASSESSED_ID"
            //                                    + " AND ASSESS_TYPE=@ASSESS_TYPE";
            //                        SqlCommand cmd = new SqlCommand(query, conn);
            //                        cmd.Parameters.AddWithValue("@MODIFIER", UserName);
            //                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", row.Cells["評核者"].FormattedValue.ToString().Substring(0, 4));
            //                        cmd.Parameters.AddWithValue("@YEAR", dtAssessedPairings.Rows[0]["YEAR"].ToString());
            //                        cmd.Parameters.AddWithValue("@ASSESSED_ID", dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim());
            //                        cmd.Parameters.AddWithValue("@ASSESS_TYPE", dtAssessedPairings.Rows[0]["ASSESS_TYPE"].ToString().Trim());
            //                        cmd.ExecuteNonQuery();
            //                    }
            //                    txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 更新" + dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim() + "主管評" + Environment.NewLine;
            //                }
            //            }
            //            else
            //            {
            //                //Setting record to Active without changing anything else
            //                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //                {
            //                    conn.Open();
            //                    string query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                                + " SET ACTIVE='1'"
            //                                + " WHERE [YEAR]=@YEAR"
            //                                + " AND ASSESSED_ID=@ASSESSED_ID"
            //                                + " AND ASSESS_TYPE=@ASSESS_TYPE";
            //                    SqlCommand cmd = new SqlCommand(query, conn);
            //                    cmd.Parameters.AddWithValue("@YEAR", dtAssessedPairings.Rows[0]["YEAR"].ToString());
            //                    cmd.Parameters.AddWithValue("@ASSESSED_ID", dtAssessedPairings.Rows[0]["ASSESSED_ID"].ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@ASSESS_TYPE", dtAssessedPairings.Rows[0]["ASSESS_TYPE"].ToString().Trim());
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //        }
            //        else if (dtAssessedPairings.Rows.Count == 0) //No pairings exist, 需新增自評與主管評
            //        {
            //            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //            {
            //                conn.Open();
            //                string query = "INSERT INTO HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //                             + " VALUES"
            //                            + " (GETDATE(),@USER,GETDATE(),@USER,@YEAR,@ASSESSED_ID,@ASSESSED_ID,'1','0','1')"
            //                            + ",(GETDATE(),@USER,GETDATE(),@USER,@YEAR,@ASSESSOR_ID,@ASSESSED_ID,'2','0','1')";
            //                SqlCommand cmd = new SqlCommand(query, conn);
            //                cmd.Parameters.AddWithValue("@USER", UserName);
            //                cmd.Parameters.AddWithValue("@YEAR", row.Cells["年份"].FormattedValue.ToString());
            //                cmd.Parameters.AddWithValue("@ASSESSOR_ID", row.Cells["評核者"].FormattedValue.ToString().Substring(0, 4));
            //                cmd.Parameters.AddWithValue("@ASSESSED_ID", row.Cells["受評者"].FormattedValue.ToString().Substring(0, 4));
            //                cmd.ExecuteNonQuery();
            //            }
            //            txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 新增加" + row.Cells["受評者"].FormattedValue.ToString().Substring(0, 4) + "自評" + Environment.NewLine;
            //            txtPersonnelAssignmentTabMemo.Text += DateTime.Now.ToString() + " 新增加" + row.Cells["受評者"].FormattedValue.ToString().Substring(0, 4) + "主管評" + Environment.NewLine;
            //        }
            //        else
            //        {
            //            txtPersonnelAssignmentTabMemo.Text += "Error: " + row.Cells["受評者"].FormattedValue.ToString() + "同樣的評核類型有超過兩個ACTIVE的紀錄" + Environment.NewLine;
            //        }
            //    }
            //    else
            //    {
            //        txtPersonnelAssignmentTabMemo.Text += "Warning: " + row.Cells["受評者"].FormattedValue.ToString() + "尚未配置評核者" + Environment.NewLine;
            //    }
            //}
        }
        #endregion     

        #region 員工應工作時數 Tab Methods and Events
        private DataTable LoadgvEmployeeWorkhourInputField()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT COALESCE(WH.[YEAR],(@YEAR)) [評核年份]"
                            + " ,LTRIM(RTRIM(MV.MV001)) [員工ID]"
                            + " ,MV.MV002 [員工姓名]"
                            + " ,COALESCE(CONVERT(NVARCHAR(10),WH.[EXPECTED_WORK_HOUR]),'') [應工作時數]"
                            + " FROM EMPLOYEE_EXPECTED_WORKHOUR WH"
                            + " RIGHT JOIN NZ.dbo.CMSMV MV ON WH.EMP_ID=MV.MV001 AND WH.[YEAR]=(@YEAR)"
                            + " WHERE (MV.MV001 NOT LIKE 'PT%'"
                            + " AND MV.MV001<>'0000'"
                            + " AND MV.MV001<>'0006'"
                            + " AND MV.MV001<>'0007'"
                            + " AND MV.MV001<>'0098'"
                            + " AND ((MV.MV021<=@YEAR+'1231' AND MV.MV022='')"
                            + " OR (MV.MV021<=@YEAR+'1231' AND MV.MV022>@YEAR+'1231')))"
                            + " OR WH.[YEAR]=@YEAR"
                            + " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", cbxEmployeeWorkhourInputYear.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void cbxEmployeeWorkhourInputYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtEmployeeWorkhourSource = LoadgvEmployeeWorkhourInputField();
            gvEmployeeWorkhourInputField.DataSource = dtEmployeeWorkhourSource;
            LoadControlStatus(tbpEmployeeWorkhourInput);
        }

        private void btnEmployeeWorkhourInputEdit_Click(object sender, EventArgs e)
        {
            employeeWorkHourInputTabMode = FunctionMode.EDIT;
            LoadControlStatus(tbpEmployeeWorkhourInput);
        }

        private void btnEmployeeWorkhourInputCancel_Click(object sender, EventArgs e)
        {
            employeeWorkHourInputTabMode = FunctionMode.STATIC;
            LoadControlStatus(tbpEmployeeWorkhourInput);
            txtEmployeeWorkhourInputTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
        }

        private void btnEmployeeWorkhourInputSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvEmployeeWorkhourInputField.Rows)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //Check for duplicate entry
                    string query = "SELECT [YEAR],[EMP_ID],[EXPECTED_WORK_HOUR]"
                                + " FROM EMPLOYEE_EXPECTED_WORKHOUR"
                                + " WHERE [YEAR]=@YEAR"
                                + " AND [EMP_ID]=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@YEAR", row.Cells["評核年份"].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@ID", row.Cells["員工ID"].FormattedValue.ToString());
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        decimal d;
                        //Already have entry, use update
                        if (dr.HasRows)
                        {
                            query = "UPDATE EMPLOYEE_EXPECTED_WORKHOUR"
                                + " SET [EXPECTED_WORK_HOUR]=@WORKHOUR"
                                + " WHERE [YEAR]=@YEAR"
                                + " AND [EMP_ID]=@ID";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@YEAR", row.Cells["評核年份"].FormattedValue.ToString());
                            cmd.Parameters.AddWithValue("@ID", row.Cells["員工ID"].FormattedValue.ToString());
                            if (decimal.TryParse(row.Cells["應工作時數"].FormattedValue.ToString(), out d))
                            {
                                cmd.Parameters.AddWithValue("@WORKHOUR", d);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@WORKHOUR", DBNull.Value);
                            }
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            query = "INSERT INTO EMPLOYEE_EXPECTED_WORKHOUR"
                                + " VALUES (@YEAR, @ID, @WORKHOUR)";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@YEAR", row.Cells["評核年份"].FormattedValue.ToString());
                            cmd.Parameters.AddWithValue("@ID", row.Cells["員工ID"].FormattedValue.ToString());
                            if (decimal.TryParse(row.Cells["應工作時數"].FormattedValue.ToString(), out d))
                            {
                                cmd.Parameters.AddWithValue("@WORKHOUR", d);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@WORKHOUR", DBNull.Value);
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            employeeWorkHourInputTabMode = FunctionMode.STATIC;
            dtEmployeeWorkhourSource = LoadgvEmployeeWorkhourInputField();
            gvEmployeeWorkhourInputField.DataSource = dtEmployeeWorkhourSource;
            LoadControlStatus(tbpEmployeeWorkhourInput);
            txtEmployeeWorkhourInputTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
        }

        #endregion

        //#region 特評分數設定 Tab Methods and Events
        //private void LoadScoreStandard()
        //{
        //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        //    {
        //        conn.Open();
        //        string query = "SELECT *"
        //                    + " FROM HR360_ASSESSMENTSCORE_STANDARD";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        scoreStandardValue = Convert.ToDecimal(cmd.ExecuteScalar());
        //    }
        //    txtScoreStandardStandard.Text = scoreStandardValue.ToString();
        //}

        //private void btnScoreStandardEdit_Click(object sender, EventArgs e)
        //{
        //    txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " 特評標準編輯開始" + Environment.NewLine;
        //    scoreStandardTabMode = FunctionMode.EDIT;
        //    LoadControlStatus(currentTabPage);
        //}

        //private void btnScoreStandardCancel_Click(object sender, EventArgs e)
        //{
        //    txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " 特評標準變更取消" + Environment.NewLine;
        //    LoadScoreStandard();
        //    scoreStandardTabMode = FunctionMode.STATIC;
        //    LoadControlStatus(currentTabPage);
        //}

        //private void btnScoreStandardSave_Click(object sender, EventArgs e)
        //{
        //    bool containsError = false;
        //    decimal d;

        //    if (!decimal.TryParse(txtScoreStandardStandard.Text, out d))
        //    {
        //        txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " Error: 輸入格式非數字" + Environment.NewLine;
        //        containsError = true;
        //    }
        //    else
        //    {
        //        if (d < 0 || d > 10)
        //        {
        //            txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " Error: 輸入數字超出範圍" + Environment.NewLine;
        //            containsError = true;
        //        }
        //        if ((d * 100) % 10 != 0)
        //        {
        //            txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " Error: 小數點僅能一位" + Environment.NewLine;
        //            containsError = true;
        //        }
        //    }

        //    if (!containsError)
        //    {
        //        txtScoreStandardTabMemo.Text += DateTime.Now.ToString() + " 變更完成:特評標準從" + scoreStandardValue.ToString() + "變更為" + txtScoreStandardStandard.Text + Environment.NewLine;
        //        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        //        {
        //            conn.Open();
        //            string query = "UPDATE HR360_ASSESSMENTSCORE_STANDARD"
        //                        + " SET SCORE_STANDARD = @STANDARD";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@STANDARD", txtScoreStandardStandard.Text);
        //            cmd.ExecuteNonQuery();
        //        }
        //        LoadScoreStandard();
        //        scoreStandardTabMode = FunctionMode.STATIC;
        //        LoadControlStatus(currentTabPage);
        //    }
        //}
        //#endregion

        #region 年份及評核時間設定 Tab Methods and Events
        private void btnYearAndEvalTimeSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "UPDATE HR360_ASSESSMENTTIME"
                            + " SET EVAL_STARTTIME=@EVAL_START_TIME"
                            + " ,EVAL_ENDTIME=@EVAL_END_TIME"
                            + " ,EVAL_SELF_STARTTIME=@SELFSTART"
                            + " ,EVAL_SELF_ENDTIME=@SELFEND"
                            + " ,EVAL_SUPERVISOR_STARTTIME=@SUPERSTART"
                            + " ,EVAL_SUPERVISOR_ENDTIME=@SUPEREND" +
                            " ,EVAL_FINALIZER_STARTTIME=@FINALSTART" +
                            " ,EVAL_FINALIZER_ENDTIME=@FINALEND" +
                            " WHERE EVAL_YEAR=@EVAL_YEAR" +
                            " IF @@ROWCOUNT=0" +
                            " INSERT INTO HR360_ASSESSMENTTIME" +
                            " VALUES (@EVAL_YEAR,@EVAL_START_TIME,@EVAL_END_TIME,@SELFSTART,@SELFEND,@SUPERSTART,@SUPEREND,@FINALSTART,@FINALEND,@EVAL_DONE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EVAL_YEAR", cbxYearAndEvalTimeYear.Text);
                cmd.Parameters.AddWithValue("@EVAL_START_TIME", dtpYearAndEvalTimeStartTime.Value);
                cmd.Parameters.AddWithValue("@EVAL_END_TIME", dtpYearAndEvalTimeEndTime.Value);
                cmd.Parameters.AddWithValue("@SELFSTART", dtpYearAndEvalTimeSelfStartTime.Value);
                cmd.Parameters.AddWithValue("@SELFEND", dtpYearAndEvalTimeSelfEndTime.Value);
                cmd.Parameters.AddWithValue("@SUPERSTART", dtpYearAndEvalTimeSupervisorStartTime.Value);
                cmd.Parameters.AddWithValue("@SUPEREND", dtpYearAndEvalTimeSupervisorEndTime.Value);
                cmd.Parameters.AddWithValue("@FINALSTART", dtpYearAndEvalTimeFinalizerStartTime.Value);
                cmd.Parameters.AddWithValue("@FINALEND", dtpYearAndEvalTimeFinalizerEndTime.Value);
                cmd.Parameters.AddWithValue("@EVAL_DONE", '0');
                cmd.ExecuteNonQuery();
            }
            txtYearAndEvalTimeTabMemo.Text += DateTime.Now.ToString() + " " + cbxYearAndEvalTimeYear.Text + "年資料更新完成" + Environment.NewLine;
        }

        private void btnYearAndEvalTimeCancel_Click(object sender, EventArgs e)
        {
            DisplayYearAndEvalTime(Convert.ToInt32(cbxYearAndEvalTimeYear.Text));
            txtYearAndEvalTimeTabMemo.Text += DateTime.Now.ToString() + " " + cbxYearAndEvalTimeYear.Text + "年資料更新取消" + Environment.NewLine;
        }

        private void cbxYearAndEvalTimeYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayYearAndEvalTime(Convert.ToInt32(cbxYearAndEvalTimeYear.Text));
            LoadControlStatus(tbpYearAndEvalTime);
        }

        private void DisplayYearAndEvalTime(int year)
        {
            DataTable dt = new DataTable();
            dt = LoadYearAndEvalTimeDate(year);

            if (dt.Rows.Count > 0)
            {
                dtpYearAndEvalTimeStartTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_STARTTIME"].ToString());
                dtpYearAndEvalTimeEndTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_ENDTIME"].ToString());
                dtpYearAndEvalTimeSelfStartTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_SELF_STARTTIME"].ToString());
                dtpYearAndEvalTimeSelfEndTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_SELF_ENDTIME"].ToString());
                dtpYearAndEvalTimeSupervisorStartTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_SUPERVISOR_STARTTIME"].ToString());
                dtpYearAndEvalTimeSupervisorEndTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_SUPERVISOR_ENDTIME"].ToString());
                dtpYearAndEvalTimeFinalizerStartTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_FINALIZER_STARTTIME"].ToString());
                dtpYearAndEvalTimeFinalizerEndTime.Value = Convert.ToDateTime(dt.Rows[0]["EVAL_FINALIZER_ENDTIME"].ToString());
            }
        }

        private DataTable LoadYearAndEvalTimeDate(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT *" +
                    " ,EVAL_STARTTIME" +
                    " ,EVAL_ENDTIME" +
                    " ,EVAL_SELF_STARTTIME" +
                    " ,EVAL_SELF_ENDTIME" +
                    " ,EVAL_SUPERVISOR_STARTTIME" +
                    " ,EVAL_SUPERVISOR_ENDTIME" +
                    " ,EVAL_FINALIZER_STARTTIME" +
                    " ,EVAL_FINALIZER_ENDTIME" +
                    " FROM HR360_ASSESSMENTTIME" +
                    " WHERE EVAL_YEAR=@YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", year);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region 帳戶權限設定 Tab Methods and Events
        private DataTable LoadgvAccountPriviledge()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(PRIV.ERP_ID))+' '+ LTRIM(RTRIM(MV.MV002)) '帳號'"
                            + " , PRIV.[VIEW] '閱覽報表權限'"
                            + " , PRIV.CALCULATE '計算成績權限'"
                            + " FROM HR360_ASSESSMENTPRIVILEDGE PRIV"
                            + " LEFT JOIN NZ.dbo.CMSMV MV ON PRIV.ERP_ID=MV.MV001"
                            + " WHERE MV.MV022=''"
                            + " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void btnAccountPriviledgeEdit_Click(object sender, EventArgs e)
        {
            accountPriviledgeTabMode = FunctionMode.EDIT;
            
            if (gvAccountPriviledge.Rows.Count <= 0)
            {
                DataRow newRow = dtAccountPriviledgeSource.NewRow();
                newRow["帳號"] = "0001 李世宗";
                dtAccountPriviledgeSource.Rows.Add(newRow);
                gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
            }
            LoadControlStatus(currentTabPage);
        }

        private void gvAccountPriviledge_KeyDown(object sender, KeyEventArgs e)
        {
            if (accountPriviledgeTabMode == FunctionMode.EDIT)
            {
                if (e.KeyData == Keys.Down)
                {

                    if (gvAccountPriviledge.CurrentRow.Index == gvAccountPriviledge.Rows.Count - 1)
                    {
                        foreach (DataGridViewCell c in gvAccountPriviledge.CurrentRow.Cells)
                        {
                            if (String.IsNullOrWhiteSpace(c.EditedFormattedValue.ToString()))
                            {
                                ShowError(201);
                                e.Handled = true;
                                break;
                            }
                        }
                        if (!e.Handled)
                        {
                            DataRow newRow = dtAccountPriviledgeSource.NewRow();
                            dtAccountPriviledgeSource.Rows.Add(newRow);
                            gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
                            if (gvAccountPriviledge.Rows.Count > 1 && gvAccountPriviledge.Enabled == true)
                            {
                                gvAccountPriviledge.CurrentCell = gvAccountPriviledge.Rows[gvAccountPriviledge.CurrentRow.Index + 1].Cells[0];
                            }
                        }
                    }
                }
            }
        }        

        private void btnAccountPriviledgeCancel_Click(object sender, EventArgs e)
        {
            
                isCancel = true;
                if (gvAccountPriviledge.Rows.Count > 0)
                {
                    if (gvAccountPriviledge.Rows[gvAccountPriviledge.Rows.Count - 1].IsNewRow)
                    {
                        gvAccountPriviledge.Rows.RemoveAt(gvAccountPriviledge.Rows.Count - 1);
                    }
                    dtAccountPriviledgeSource = LoadgvAccountPriviledge();
                    gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
                }
                accountPriviledgeTabMode = FunctionMode.STATIC;
                LoadControlStatus(currentTabPage);
                txtAccountPriviledgeTabMemo.Text += DateTime.Now.ToString() + " 資料更新取消" + Environment.NewLine;
                isCancel = false;
            
        }
        
        private void gvAccountPriviledge_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isCancel)
            {
                if (String.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    ShowError(101);
                    e.Cancel = true;
                }
            }
        }

        private void btnAccountPriviledgeSave_Click(object sender, EventArgs e)
        {
            DataTable dtOriginalTable = LoadgvAccountPriviledge();
            tbcManagement.Enabled = false;
            gvAccountPriviledge.DataSource = null;
            for (int i = 0; i < dtOriginalTable.Rows.Count; i++)
            {
                dtOriginalTable.Rows[i]["帳號"] = dtOriginalTable.Rows[i]["帳號"].ToString().Substring(0, 4);
            }
            for (int i = 0; i < dtAccountPriviledgeSource.Rows.Count; i++)
            {
                if (dtAccountPriviledgeSource.Rows[i].RowState != DataRowState.Deleted)
                {
                    dtAccountPriviledgeSource.Rows[i]["帳號"] = dtAccountPriviledgeSource.Rows[i]["帳號"].ToString().Substring(0, 4);
                }

            }
            CompareTables(dtOriginalTable, dtAccountPriviledgeSource);
            var tempRow = dtAccountPriviledgeSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.EDITED.ToString()).OrderBy(y => y["帳號"]);
            DataTable dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtAccountPriviledgeSource.Clone();
            
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                //perform DB update by using data in dtSourceInterim                
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE HR360_ASSESSMENTPRIVILEDGE"
                                + " SET [VIEW]=@VIEW"
                                + " ,CALCULATE=@CALCULATE"
                                + " WHERE ERP_ID=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VIEW", dtSourceInterim.Rows[i]["閱覽報表權限"].ToString());
                    cmd.Parameters.AddWithValue("@CALCULATE", dtSourceInterim.Rows[i]["計算成績權限"].ToString());
                    cmd.Parameters.AddWithValue("@ID", dtSourceInterim.Rows[i]["帳號"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            
            tempRow = dtAccountPriviledgeSource.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.NEW.ToString()).OrderBy(y => y["帳號"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtAccountPriviledgeSource.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["閱覽報表權限"].ToString()))
                {
                    dtSourceInterim.Rows[i]["閱覽報表權限"] = 0;
                }
                if (String.IsNullOrWhiteSpace(dtSourceInterim.Rows[i]["計算成績權限"].ToString()))
                {
                    dtSourceInterim.Rows[i]["計算成績權限"] = 0;
                }
                //perform DB insert
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO HR360_ASSESSMENTPRIVILEDGE(ERP_ID,[VIEW],CALCULATE)"
                                +" VALUES (@ID, @VIEW, @CALCULATE)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VIEW", dtSourceInterim.Rows[i]["閱覽報表權限"].ToString());
                    cmd.Parameters.AddWithValue("@CALCULATE", dtSourceInterim.Rows[i]["計算成績權限"].ToString());
                    cmd.Parameters.AddWithValue("@ID", dtSourceInterim.Rows[i]["帳號"].ToString());
                    cmd.ExecuteNonQuery();
                }                
            }
            tempRow = dtOriginalTable.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted && (string)x["EDIT_STATUS"] == TableRowStatus.DELETED.ToString()).OrderBy(y => y["帳號"]);
            dtSourceInterim = new DataTable();
            dtSourceInterim = tempRow.Any() ? tempRow.CopyToDataTable() : dtOriginalTable.Clone();
            for (int i = 0; i < dtSourceInterim.Rows.Count; i++)
            {
                try
                {
                    //perform DB delete
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE HR360_ASSESSMENTPRIVILEDGE"
                                    + " WHERE ERP_ID=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", dtSourceInterim.Rows[i]["帳號"].ToString());
                        cmd.ExecuteNonQuery();
                    } 
                }
                catch
                {                   
                    ShowError(401);
                    break;                    
                }
            }
            dtAccountPriviledgeSource = LoadgvAccountPriviledge();
            gvAccountPriviledge.DataSource = dtAccountPriviledgeSource;
            tbcManagement.Enabled = true;
            accountPriviledgeTabMode = FunctionMode.STATIC;
            txtAccountPriviledgeTabMemo.Text += DateTime.Now.ToString() + " 資料更新完成" + Environment.NewLine;
            LoadControlStatus(currentTabPage);
        }
        #endregion

        #region 報表預覽 Tab Methods and Events
        private void LoadcbxReportPreviewEmployee()
        {
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(MV.MV001))+' '+LTRIM(RTRIM(MV.MV002)) 'NAME',MV.MV002 'ID'"
                            + " FROM CMSMV MV"
                            + " WHERE"
                            + " MV.MV021<@YEAR+'1231'"
                            + " AND (MV.MV022 = '' OR MV.MV022>@YEAR+'1231')"
                            + " AND MV.MV001<>'0000'"
                            + " AND MV.MV001<>'0098'"
                            + " AND MV.MV001 NOT LIKE 'PT%'"
                            + " ORDER BY MV.MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", cbxReportPreviewYear.Text);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {                            
                            cbxReportPreviewEmployee.Items.Add(dr.GetString(0));
                        }
                    }
                }
            }
            if (cbxReportPreviewEmployee.Items.Count > 0)
            {
                cbxReportPreviewEmployee.SelectedIndex = 0;
            }
        }
        private void cbxReportPreviewYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxReportPreviewEmployee.Items.Clear();
            LoadcbxReportPreviewEmployee();
        }        

        private void btnReportPreviewPreview_Click(object sender, EventArgs e)
        {
            PassStringValueFromWinFormToWebForm();
        }

        private void PassStringValueFromWinFormToWebForm()
        {            
            System.Diagnostics.Process.Start("http://www.nizing.com.tw/hr360/evaluationFormView.aspx" + "?year=" + cbxReportPreviewYear.Text + "&ID=" + cbxReportPreviewEmployee.Text.Substring(0, 4));            
        }
        #endregion

        #region 最終成績計算 Tab Methods and Events
        private void btnFinalScoreCalculate_Click(object sender, EventArgs e)
        {
            DataTable dtScores = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT A.[YEAR] [年度]" +
                    " ,A.ASSESSED_ID[受評者ID]" +
                    " ,B.WEIGHTED_SCORE[自評分數]" +
                    " ,C.WEIGHTED_SCORE[主管評分數]" +
                    " ,D.WEIGHTED_SCORE[核決主管評分數]" +
                    " ,SCORE.ATTENDANCE_SCORE[出勤成績]" +
                    " ,COALESCE(SCORE.RNP_SCORE, null)[獎懲成績]" +
                    " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                    " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID = MV.MV001" +
                    " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID = SCORE.ASSESSOR_ID AND A.ASSESSED_ID = SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" +
                    " LEFT JOIN" +
                    " (" +
                    " SELECT A.ASSESSED_ID, AVG(CONVERT(DECIMAL(5,2),SCORE.WEIGHTED_SCORE)) 'WEIGHTED_SCORE'" +
                    " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                    " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" +
                    " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='1'" +
                    " AND A.[YEAR]= @YEAR" +
                    " GROUP BY A.ASSESSED_ID" +
                    " ) B ON A.ASSESSOR_ID=B.ASSESSED_ID" +
                    " LEFT JOIN" +
                    " (" +
                    " SELECT A.ASSESSED_ID, AVG(CONVERT(DECIMAL(5,2),SCORE.WEIGHTED_SCORE)) 'WEIGHTED_SCORE'" +
                    " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                    " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" +
                    " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='2'" +
                    " AND A.[YEAR]= @YEAR" +
                    " GROUP BY A.ASSESSED_ID" +
                    " ) C ON A.ASSESSOR_ID=C.ASSESSED_ID" +
                    " LEFT JOIN" +
                    " (" +
                    " SELECT A.ASSESSED_ID, SCORE.WEIGHTED_SCORE" +
                    " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                    " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID= SCORE.ASSESSOR_ID AND A.ASSESSED_ID= SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                    " WHERE A.ACTIVE= '1' AND A.ASSESS_TYPE= '3'" +
                    " AND A.[YEAR]= @YEAR" +
                    " ) D ON A.ASSESSOR_ID=D.ASSESSED_ID" +
                    " WHERE A.ACTIVE='1'" +
                    " AND A.ASSESS_TYPE='1'" +
                    " AND A.[YEAR]= @YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", cbxFinalScoreYear.SelectedItem.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtScores);
            }
            CalculateFinalScore(dtScores);
            txtFinalScoreMemo.Text += DateTime.Now.ToString() + " 最終成績計算完成" + Environment.NewLine;
        }
        protected void CalculateFinalScore(DataTable dt)
        {
            DataTable dtScoreWeight = new DataTable();
            dtScoreWeight = GetScoreWeight(Convert.ToInt32(cbxFinalScoreYear.SelectedItem));

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string year = dt.Rows[i]["年度"].ToString();
                    string id = dt.Rows[i]["受評者ID"].ToString();
                    double attendanceScore = 0;                    
                    double rnpScore = 0;
                    double selfEvalScore = 0;
                    double superEvalScore = 0;
                    double finalEvalScore = 0;
                    double finalScore = 0;
                    string finalGrade = "";
                    double selfEvalWeight = Convert.ToDouble(dtScoreWeight.Rows[0]["scoreWeight"].ToString());
                    double superEvalWeight = Convert.ToDouble(dtScoreWeight.Rows[1]["scoreWeight"].ToString());
                    double finalEvalWeight = Convert.ToDouble(dtScoreWeight.Rows[2]["scoreWeight"].ToString());
                    if (!isSupervisorAssigned(year, id))
                    {
                        finalEvalWeight += superEvalWeight;
                    }                    

                    double evalScore = 0;

                    if (!double.TryParse(dt.Rows[i]["自評分數"].ToString(), out selfEvalScore))
                    {
                        selfEvalScore = 0;
                    }
                    if (!double.TryParse(dt.Rows[i]["主管評分數"].ToString(), out superEvalScore))
                    {
                        superEvalScore = 0;
                    }
                    if (!double.TryParse(dt.Rows[i]["核決主管評分數"].ToString(), out finalEvalScore))
                    {
                        finalEvalScore = 0;
                    }                    
                    if (!double.TryParse(dt.Rows[i]["出勤成績"].ToString(), out attendanceScore))
                    {
                        attendanceScore = 0;
                    }
                    if (!double.TryParse(dt.Rows[i]["獎懲成績"].ToString(), out rnpScore))
                    {
                        rnpScore = 0;
                    }
                    //if (!double.TryParse(dt.Rows[i]["特評分數"].ToString(), out evalScore))
                    //{
                    //    evalScore = Convert.ToDouble(dt.Rows[i]["主管評分數"]);
                    //}
                    evalScore = (selfEvalScore * selfEvalWeight / 10) + (superEvalScore * superEvalWeight / 10) + (finalEvalScore * finalEvalWeight / 10);
                    finalScore = evalScore * 0.8 + attendanceScore * 0.2 + rnpScore;

                    if (finalScore >= 90)
                    {
                        finalGrade = "甲";
                    }
                    else if (finalScore >= 80)
                    {
                        finalGrade = "乙";
                    }
                    else if (finalScore >= 70)
                    {
                        finalGrade = "丙";
                    }
                    else
                    {
                        finalGrade = "丁";
                    }
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE HR360_AssessmentScore_FinalScore"
    + " Set EvaluationScore=@EvaluationScore"
    + " ,AttendanceScore=@AttendanceScore"
    + " ,RewardAndPenaltyScore=@RewardAndPenaltyScore"
    + " ,FinalScore=@FinalScore"
    + " ,FinalScoreGrade=@FinalScoreGrade"
    + " Where AssessYear=@AssessYear"
    + " and EmpID=@EmpID"
    + " IF @@ROWCOUNT=0"
    + " INSERT INTO HR360_AssessmentScore_FinalScore(AssessYear,EmpID,EvaluationScore,AttendanceScore,RewardAndPenaltyScore,FinalScore,FinalScoreGrade)"
    + " VALUES(@AssessYear,@EmpID,@EvaluationScore,@AttendanceScore,@RewardAndPenaltyScore,@FinalScore,@FinalScoreGrade)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@AssessYear", year);
                        cmd.Parameters.AddWithValue("@EmpID", id);
                        cmd.Parameters.AddWithValue("@EvaluationScore", evalScore);
                        cmd.Parameters.AddWithValue("@AttendanceScore", attendanceScore);
                        cmd.Parameters.AddWithValue("@RewardAndPenaltyScore", rnpScore);
                        cmd.Parameters.AddWithValue("@FinalScore", finalScore);
                        cmd.Parameters.AddWithValue("@FinalScoreGrade", finalGrade);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                txtFinalScoreMemo.Text += DateTime.Now.ToString() + ex.Message + Environment.NewLine;
            }
        }
        private void cbxFinalScoreYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadControlStatus(tbpFinalScoreCalculation);
        }

        private DataTable GetScoreWeight(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT assessType" +
                    " ,scoreWeight" +
                    " FROM HR360_AssessmentCategory_CategoryWeight" +
                    " WHERE assessYear = @year" +
                    " order by assessType";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        private bool isSupervisorAssigned(string year, string assessedId)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "select assessorSupervisorAmount" +
                    " from HR360_AssessmentPersonnel_Assignment_B" +
                    " where assessYear = @year" +
                    " and assessedID = @assessedId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@assessedId", assessedId);
                return cmd.ExecuteScalar() != null && Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }
        private void btnFinalScoreAssessmentDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "update HR360_ASSESSMENTTIME" +
                    " set EVAL_DONE='1'" +
                    " where EVAL_YEAR=@assessYear";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assessYear", Convert.ToInt32(cbxFinalScoreYear.SelectedItem));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


    }
}
