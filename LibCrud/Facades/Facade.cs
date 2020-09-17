using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    public class Facade
    {
        #region Attributes and Enums
        private PhysicalPersonController _ppc;
        private JuridicalPersonController _jpc;
        private UserController _uc;
        private PersonFactory _pf;
        private User _user;
        private string _errors = "";
        private Log _log = Log.GetLogInstance;
        

        public enum OptionPerson
        {
            PhysicalPersonOption,
            JuridicalPersonOption
        }

        public enum OptionAVGSalary
        {
            Above,
            Under,
            Equal
        }

        public enum OptionSalary
        {
            Lower,
            Higher
        }

        public enum OptionGender
        {
            Male,
            Female
        }
        #endregion

        #region Facade
        Facade()
        {
        }
        static Facade()
        {
        }
        static readonly Facade facadeInstance = new Facade();
        public static Facade FacadeInstance
        {
            get { return facadeInstance; }
        }
        #endregion

        #region Error
        private void SetError(string error)
        {
            _errors = _errors + (error + Environment.NewLine);
        }
        #endregion

        #region Validation (PhysicalPerson)
        private void ValidationPhysicalPerson(PhysicalPerson pf)
        {
            _log.SetLog("ValidationPhysicalPerson", "Starting Physical Person validation.", DateTime.Now);

            FacadeValidationData validation = FacadeValidationData.GetInstance;
            bool vemail = false;
            _errors = "";

            if (new StackTrace().GetFrame(1).GetMethod().Name != "InsertPhysicalPerson")
            {
                if (validation.CheckIfNotIsNullOrEmpty(pf.Id.ToString()))
                {
                    if (!validation.CheckNumericRange<int>(pf.Id, 0, int.MaxValue))
                    {
                        SetError("Invalid ID.");
                    }
                }
                else
                {
                    SetError("ID is empty.");
                }
            }

            if (new StackTrace().GetFrame(1).GetMethod().Name != "DeletePhysicalPerson")
            {
                if (new StackTrace().GetFrame(1).GetMethod().Name == "InsertPhysicalPerson")
                {
                    if (validation.CheckIfNotIsNullOrEmpty(pf.Cpf))
                    {
                        if (validation.CheckStringSize(pf.Cpf, 11, 11))
                        {
                            if (validation.CheckRegex(pf.Cpf, @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"))
                            {
                                if (validation.ValidateCPF(pf.Cpf))
                                {
                                    if (validation.CheckIfExistInDatabase<string>("PHYSICALPERSON", "CPF", pf.Cpf))
                                    {
                                        SetError("CPF already registered.");
                                    }
                                }
                                else
                                {
                                    SetError("Invalid CPF.");
                                }
                            }
                            else
                            {
                                SetError("Invalid CPF.");
                            }
                        }
                        else
                        {
                            SetError("Invalid character quantity for CPF.");
                        }
                    }
                    else
                    {
                        SetError("CPF is empty.");
                    }
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Name))
                {
                    if (!validation.CheckStringSize(pf.Name, 3, 45))
                    {
                        SetError("Invalid character quantity for name.");
                    }
                }
                else
                {
                    SetError("Name is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Email))
                {
                    if (validation.CheckStringSize(pf.Email, 7, 45))
                    {
                        if (validation.CheckRegex(pf.Email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
                        {
                            if (new StackTrace().GetFrame(1).GetMethod().Name == "EditPhysicalPerson")
                            {
                                PersonFacade personFacade = this.GetPhysicalPersonByID(_pf.GetPerson().Id);
                                if (personFacade != null)
                                {
                                    vemail = (pf.Email != personFacade.Email);
                                }
                            }

                            if (vemail)
                            {
                                if (validation.CheckIfExistInDatabase<string>("PERSON", "EMAIL", pf.Email))
                                {
                                    SetError("E-mail already registered.");
                                }
                            }
                        }
                        else
                        {
                            SetError("Invalid e-mail.");
                        }
                    }
                    else
                    {
                        SetError("Invalid character quantity for e-mail.");
                    }
                }
                else
                {
                    SetError("E-mail is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Salary.ToString()))
                {
                    if (!validation.CheckNumericRange<decimal>(pf.Salary, 0, decimal.MaxValue))
                    {
                        SetError("Invalid salary.");
                    }
                }
                else
                {
                    SetError("Salary is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Birthday.ToString()))
                {
                    if (!validation.CheckYear(pf.Birthday, 0, 0, -18))
                    {
                        SetError("Invalid birthday.");
                    }
                }
                else
                {
                    SetError("Birthday is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Gender.ToString()))
                {
                    if (validation.CheckStringSize(pf.Gender.ToString(), 1, 1))
                    {
                        if (!validation.CheckRegex(pf.Gender.ToString(), @"[M{1},F{1}]"))
                        {
                            SetError("Invalid gender.");
                        }
                    }
                    else
                    {
                        SetError("Invalid character quantity for gender.");
                    }
                }
                else
                {
                    SetError("Gender is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(pf.Status.ToString()))
                {
                    if (!validation.CheckRegex(pf.Status.ToString(), @"^(true|false)$"))
                    {
                        SetError("Invalid status.");
                    }
                }
                else
                {
                    SetError("Status is empty.");
                }
            }

            if (_errors == "")
            {
                _log.SetLog("ValidationPhysicalPerson", "Starting Physical Person validation.", DateTime.Now);
            }
            else
            {
                _log.SetLog("ValidationPhysicalPerson", "Error Physical Person validating." + Environment.NewLine + "ERRORS:" + Environment.NewLine + _errors, DateTime.Now);
            }
        }
        #endregion

        #region Validation (JuridicalPerson)
        private void ValidationJuridicalPerson(JuridicalPerson jp)
        {
            _log.SetLog("ValidationJuridicalPerson", "Starting Juridical Person validation.", DateTime.Now);

            FacadeValidationData validation = FacadeValidationData.GetInstance;
            _errors = "";

            if (new StackTrace().GetFrame(1).GetMethod().Name != "InsertJuridicalPerson")
            {
                if (validation.CheckIfNotIsNullOrEmpty(jp.Id.ToString()))
                {
                    if (!validation.CheckNumericRange<int>(jp.Id, 1, int.MaxValue))
                    {
                        SetError("Invalid ID.");
                    }
                }
                else
                {
                    SetError("ID is empty.");
                }
            }

            if (new StackTrace().GetFrame(1).GetMethod().Name != "DeleteJuridicalPerson")
            {
                if (new StackTrace().GetFrame(1).GetMethod().Name == "InsertJuridicalPerson")
                {
                    if (validation.CheckIfNotIsNullOrEmpty(jp.Cnpj))
                    {
                        if (validation.CheckStringSize(jp.Cnpj, 14, 14))
                        {
                            if (validation.CheckRegex(jp.Cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
                            {
                                if (validation.ValidateCNPJ(jp.Cnpj))
                                {
                                    if (validation.CheckIfExistInDatabase<string>("JURIDICALPERSON", "CNPJ", jp.Cnpj))
                                    {
                                        SetError("CNPJ already registered.");
                                    }
                                }
                                else
                                {
                                    SetError("Invalid CNPJ.");
                                }
                            }
                            else
                            {
                                SetError("Invalid CNPJ.");
                            }
                        }
                        else
                        {
                            SetError("Invalid character quantity for CNPJ.");
                        }
                    }
                    else
                    {
                        SetError("CNPJ is empty.");
                    }
                }


                if (validation.CheckIfNotIsNullOrEmpty(jp.Name))
                {
                    if (!validation.CheckStringSize(jp.Name, 3, 45))
                    {
                        SetError("Invalid character quantity for name.");
                    }
                }
                else
                {
                    SetError("Name is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(jp.Email))
                {
                    if (validation.CheckStringSize(jp.Email, 7, 45))
                    {
                        if (validation.CheckRegex(jp.Email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
                        {
                            if (new StackTrace().GetFrame(1).GetMethod().Name == "EditJuridicalPerson")
                            {
                                PersonFacade personFacade = this.GetJuridicalPersonByID(_pf.GetPerson().Id);
                                if (personFacade != null)
                                {
                                    if (jp.Email != personFacade.Email)
                                    {
                                        if (validation.CheckIfExistInDatabase<string>("PERSON", "EMAIL", jp.Email))
                                        {
                                            SetError("E-mail already registered.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (validation.CheckIfExistInDatabase<string>("PERSON", "EMAIL", jp.Email))
                                {
                                    SetError("E-mail already registered.");
                                }
                            }
                        }
                        else
                        {
                            SetError("Invalid e-mail.");
                        }
                    }
                    else
                    {
                        SetError("Invalid character quantity for e-mail.");
                    }
                }
                else
                {
                    SetError("E-mail is empty.");
                }


                if (validation.CheckIfNotIsNullOrEmpty(jp.Status.ToString()))
                {
                    if (!validation.CheckRegex(jp.Status.ToString(), @"^(true|false)$"))
                    {
                        SetError("Invalid status.");
                    }
                }
                else
                {
                    SetError("Status is empty.");
                }
            }

            if (_errors == "")
            {
                _log.SetLog("ValidationJuridicalPerson", "Starting Juridical Person validation.", DateTime.Now);
            }
            else
            {
                _log.SetLog("ValidationJuridicalPerson", "Error Juridical Person validating." + Environment.NewLine + "ERRORS:" + Environment.NewLine + _errors, DateTime.Now);
            }
        }
        #endregion

        #region PhysicalPerson
        public object InsertPhysicalPerson(string cpf, string name, string email, decimal salary, DateTime birthday, char gender, string comment, bool status)
        {
            _pf = new PhysicalPersonFactory(0, cpf, name, email, salary, birthday, gender, comment, status);
            PhysicalPerson pp = (PhysicalPerson)_pf.GetPerson();
            this.ValidationPhysicalPerson(pp);
            if (string.IsNullOrEmpty(_errors))
            {
                _ppc = new PhysicalPersonController(pp);
                return _ppc.Insert_PhysicalPerson();
            }
            return _errors;
        }
        public object EditPhysicalPerson(int id, string name, string email, decimal salary, DateTime birthday, char gender, string comment, bool status)
        {
            _pf = new PhysicalPersonFactory(id, "", name, email, salary, birthday, gender, comment, status);
            PhysicalPerson pp = (PhysicalPerson)_pf.GetPerson();
            this.ValidationPhysicalPerson(pp);
            if (string.IsNullOrEmpty(_errors))
            {
                _ppc = new PhysicalPersonController(pp);
                return _ppc.Edit_PhysicalPerson();
            }
            return _errors;
        }
        public object DeletePhysicalPerson(int id)
        {
            _pf = new PhysicalPersonFactory(id, "", "", "", 0, new DateTime(), 'F', "", true);
            PhysicalPerson pp = (PhysicalPerson)_pf.GetPerson();
            this.ValidationPhysicalPerson(pp);
            if (string.IsNullOrEmpty(_errors))
            {
                _ppc = new PhysicalPersonController(pp);
                return _ppc.Delete_PhysicalPerson();
            }
            return _errors;
        }
        public List<PersonFacade> GetPersonByName(string name, OptionPerson optionPerson)
        {
            if (optionPerson == OptionPerson.PhysicalPersonOption)
            {
                _pf = new PhysicalPersonFactory(0, "", name, "", 0, new DateTime(), 'F', "", true);
                _ppc = new PhysicalPersonController(_pf.GetPerson());
                return _ppc.GetPersonByName();
            }
            else
            {
                _pf = new JuridicalPersonFactory(0, "", name, "", "", "", true);
                _jpc = new JuridicalPersonController(_pf.GetPerson());
                return _jpc.GetPersonByName();
            }
        }
        public PersonFacade GetPhysicalPersonByCPF(string cpf)
        {
            _pf = new PhysicalPersonFactory(0, cpf, "", "", 0, DateTime.Now, 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());
            return _ppc.GetPhysicalPersonByIdentity(PhysicalPersonController.OptionIdentity.CPF);
        }
        public PersonFacade GetPhysicalPersonByID(int id)
        {
            _pf = new PhysicalPersonFactory(id, "", "", "", 0, DateTime.Now, 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());
            return _ppc.GetPhysicalPersonByIdentity(PhysicalPersonController.OptionIdentity.ID);
        }
        #endregion

        #region JuridicalPerson
        public object InsertJuridicalPerson(string cnpj, string name, string companyName, string email, string comment, bool status)
        {
            _pf = new JuridicalPersonFactory(0, cnpj, name, companyName, email, comment, status);
            JuridicalPerson jp = (JuridicalPerson)_pf.GetPerson();
            this.ValidationJuridicalPerson(jp);
            if (string.IsNullOrEmpty(_errors))
            {
                _jpc = new JuridicalPersonController(jp);
                return _jpc.Insert_JuridicalPerson();
            }
            return _errors;
        }
        public object EditJuridicalPerson(int id, string name, string companyName, string email, string comment, bool status)
        {
            _pf = new JuridicalPersonFactory(id, "", name, companyName, email, comment, status);
            JuridicalPerson jp = (JuridicalPerson)_pf.GetPerson();
            this.ValidationJuridicalPerson(jp);
            if (string.IsNullOrEmpty(_errors))
            {
                _jpc = new JuridicalPersonController(jp);
                return _jpc.Edit_JuridicalPerson();
            }
            return _errors;
        }
        public object DeleteJuridicalPerson(int id)
        {
            _pf = new JuridicalPersonFactory(id, "", "", "", "", "", true);
            JuridicalPerson jp = (JuridicalPerson)_pf.GetPerson();
            this.ValidationJuridicalPerson(jp);
            if (string.IsNullOrEmpty(_errors))
            {
                _jpc = new JuridicalPersonController(jp);
                return _jpc.Delete_JuridicalPerson();
            }
            return _errors;
        }
        public PersonFacade GetJuridicalPersonByCNPJ(string cnpj)
        {
            _pf = new JuridicalPersonFactory(0, cnpj, "", "", "", "", true);
            _jpc = new JuridicalPersonController(_pf.GetPerson());
            return _jpc.GetJuridicalPersonByIdentity(JuridicalPersonController.OptionIdentity.CNPJ);
        }
        public PersonFacade GetJuridicalPersonByID(int id)
        {
            _pf = new JuridicalPersonFactory(id, "", "", "", "", "", true);
            _jpc = new JuridicalPersonController(_pf.GetPerson());
            return _jpc.GetJuridicalPersonByIdentity(JuridicalPersonController.OptionIdentity.ID);
        }
        #endregion

        #region Reports (PhysicalPerson)
        public List<PersonFacade> GetPhysicalPersonByAVGSalary(OptionAVGSalary optionAVGSalary)
        {
            _pf = new PhysicalPersonFactory(0, "", "", "", 0, new DateTime(), 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());
            PhysicalPersonController.OptionAVGSalary optionAVGSalaryCtr;
            optionAVGSalaryCtr = PhysicalPersonController.OptionAVGSalary.Under;

            switch (optionAVGSalary)
            {
                case OptionAVGSalary.Under:
                    optionAVGSalaryCtr = PhysicalPersonController.OptionAVGSalary.Under;
                    break;
                case OptionAVGSalary.Equal:
                    optionAVGSalaryCtr = PhysicalPersonController.OptionAVGSalary.Equal;
                    break;
                case OptionAVGSalary.Above:
                    optionAVGSalaryCtr = PhysicalPersonController.OptionAVGSalary.Above;
                    break;
            }

            return _ppc.GetPhysicalPersonByAVGSalary(optionAVGSalaryCtr);
        }

        public PersonFacade GetPhysicalPersonBySalary(OptionSalary optionSalary)
        {
            _pf = new PhysicalPersonFactory(0, "", "", "", 0, new DateTime(), 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());

            PhysicalPersonController.OptionSalary optionSalaryCtr;
            optionSalaryCtr = PhysicalPersonController.OptionSalary.Higher;

            switch (optionSalary)
            {
                case OptionSalary.Lower:
                    optionSalaryCtr = PhysicalPersonController.OptionSalary.Lower;
                    break;
                case OptionSalary.Higher:
                    optionSalaryCtr = PhysicalPersonController.OptionSalary.Higher;
                    break;
            }

            return _ppc.GetPhysicalPersonBySalary(optionSalaryCtr);
        }

        public List<PersonFacade> GetPhysicalPersonByBirthMonth(int month)
        {
            _pf = new PhysicalPersonFactory(0, "", "", "", 0, new DateTime(), 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());
            return _ppc.GetPhysicalPersonByBirthMonth(month);
        }

        public List<PersonFacade> GetPhysicalPersonBySalaryRange(decimal salaryInitial, decimal salaryFinal)
        {
            _pf = new PhysicalPersonFactory(0, "", "", "", 0, new DateTime(), 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());
            return _ppc.GetPhysicalPersonBySalaryRange(salaryInitial, salaryFinal);
        }

        public List<PersonFacade> GetPhysicalPersonByGender(OptionGender optionGender)
        {
            _pf = new PhysicalPersonFactory(0, "", "", "", 0, new DateTime(), 'F', "", true);
            _ppc = new PhysicalPersonController(_pf.GetPerson());


            PhysicalPersonController.OptionGender optionGenderCtr;
            optionGenderCtr = PhysicalPersonController.OptionGender.Female;

            switch (optionGender)
            {
                case OptionGender.Female:
                    optionGenderCtr = PhysicalPersonController.OptionGender.Female;
                    break;
                case OptionGender.Male:
                    optionGenderCtr = PhysicalPersonController.OptionGender.Male;
                    break;
            }

            return _ppc.GetPhysicalPersonByGender(optionGenderCtr);
        }
        #endregion

        #region User
        public int Login(String username, String password)
        {
            _user = new User();
            _user.Username = username;
            _user.Password = password;
            _uc = new UserController(_user);
            return _uc.Login();
        }
        public int InsertUser(String username, String password)
        {
            _user = new User();
            _user.Username = username;
            _user.Password = password;
            _uc = new UserController(_user);
            return _uc.InsertUser();
        }

        public int DeleteUser(int id)
        {
            _user = new User();
            _user.Id = id;
            _uc = new UserController(_user);
            return _uc.DeletetUser();
        }
        #endregion
    }
}
