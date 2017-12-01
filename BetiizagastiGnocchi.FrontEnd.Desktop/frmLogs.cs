using BetizagastiGnocchi.BackEnd.Services.LogServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	public partial class frmLogs : Form
	{
		public frmLogs()
		{
			InitializeComponent();
		}
		private void btnSearch_Click_1(object sender, EventArgs e)
		{
	DateTime dateFrom = dtpDateFrom.Value.Date;
			DateTime dateTo = dtpDateTo.Value.Date;
			ILogService _logger = new LogService();
			var logs = _logger.GetLog(dateFrom, dateTo);
			grdLogs.DataSource = logs;
		}

        private void grbResults_Enter(object sender, EventArgs e)
        {

        }
    }
}
