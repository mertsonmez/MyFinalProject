using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //private bool v1;
        //private string v2;

        //c# da this demek classın kendisine denir !!
        public Result(bool success, string message) : this(success) //birde bu classın tek parametreli olanını çalıştır demek
        {
            //getter readonly dir. constructor içerisinde set edilebilir !!!
            Message = message;
            //Success = success; DRY a uymak için tekrarlayan kodu kaldırdım !!


            //this.v1 = v1;
            //this.v2 = v2;
        }

        public Result(bool success)
        {
            //mesaj yazmak istemezse diye contructor overloading yapıp sadece true false döndüren bir medhod daha oluşturduk.
            Success = success;

        }

        public bool Success { get; }

        public string Message { get; }
    }
}
