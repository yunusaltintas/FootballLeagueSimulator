using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.ResponseModel
{
    public class ReturnModel : Return
    {
        public ReturnModel()
        {
            this.Success = true;
        }
        public ReturnModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Success = false;
        }
    }   
}
