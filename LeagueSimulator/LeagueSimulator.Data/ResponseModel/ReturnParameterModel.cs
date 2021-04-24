using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.ResponseModel
{
    public class ReturnParameterModel<T> : Return
    {
        public T Model { get; set; }
        public ReturnParameterModel(T model)
        {
            this.Success = true;
            this.Model = model;
        }
        public ReturnParameterModel(string errormessage)
        {
            this.ErrorMessage = errormessage;
            this.Success = false;
        }

    }
}
