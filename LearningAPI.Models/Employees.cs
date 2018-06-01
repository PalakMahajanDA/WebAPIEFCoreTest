using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using FluentValidation.WebApi;

namespace LearningAPI.Models
{
    //[CustomizeValidator(typeof(CustomerValidator),"fd","dsffs",false)]
    /// <summary>
    /// This is employee class 
    /// </summary>
        [DataContract]
    public class Employees 
    {  
        /// <summary>
        /// This is ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// This is First Name
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// This is Last Name
        /// </summary>
      
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression("^[^<>'\"]+$", ErrorMessage = "Special Character Don't allowance.")]
        [Description("describe this field")]
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// This is Manager id
        /// </summary>
        [Required]
        [Description()]
        [DataMember]
        public int? ManagerID { get; set; }

        /// <summary>
        /// This is Salary
        /// </summary>
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [DataMember]
        public Decimal? Salary { get; set; }

        /// <summary>
        /// Leave Date is mandatory when employee is present
        /// </summary>
        [DataType(DataType.DateTime)]
        [DataMember]
        public DateTime LeaveDate { get; set; }

        //[Required]
        //public string Status { get; set; }
       
        //public string Spouse_FirstName { get; set; }
        //public string Spouse_LastName { get; set; }

        
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Status))
        //    {
        //        if (Status.ToLower() == "married" && (string.IsNullOrEmpty(Spouse_FirstName)|| string.IsNullOrEmpty(Spouse_LastName)))
        //        {
        //            yield return new ValidationResult("Please Provide Spouse Name if Married");
        //        }


        //    }
        //}
    }
}
