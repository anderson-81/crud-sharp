using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSharp
{
    public class ReportDesignData
    {
        public enum ReportDesignOption
        {
            ReportPhysicalPerson,
            ReportSalaryRange,
            ReportAverageWaze,
            ReportBySalary,
            ReportByMonth,
            ReportJuridicalPerson
        }

        private string title;
        private string design;
        private object dataSource;

        public ReportDesignData(ReportDesignOption reportDesignOption, object dataSource)
        {
            this.dataSource = dataSource;
            SetDesignReport(reportDesignOption);
        }

        public string Title
        {
            get { return title; }
        }

        public string Design
        {
            get { return design; }
        }

        public object DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        private void SetDesignReport(ReportDesignOption reportDesignOption)
        {
            switch (reportDesignOption)
            {
                case ReportDesignOption.ReportPhysicalPerson:
                    this.title = "Report - Physical Person Report";
                    this.design = "CrudSharp.Reports.RpPhysicalPerson.rdlc";
                    break;
                case ReportDesignOption.ReportSalaryRange:
                    this.title = "Report - Report by Salary Range";
                    this.design = "CrudSharp.Reports.RpSalaryRange.rdlc";
                    break;
                case ReportDesignOption.ReportAverageWaze:
                    this.title = "Report - Average Salary Report";
                    this.design = "CrudSharp.Reports.RpAverageWage.rdlc";
                    break;
                case ReportDesignOption.ReportBySalary:
                    this.title = "Report - Report By Salary";
                    this.design = "CrudSharp.Reports.RpBySalary.rdlc";
                    break;
                case ReportDesignOption.ReportByMonth:
                    this.title = "Report - Birthday Report of Physical Person by Month";
                    this.design = "CrudSharp.Reports.RpByMonth.rdlc";
                    break;
                case ReportDesignOption.ReportJuridicalPerson:
                    this.title = "Report - Juridical Person Report";
                    this.design = "CrudSharp.Reports.RpJuridicalPerson.rdlc";
                    break;
            }
        }
    }
}
