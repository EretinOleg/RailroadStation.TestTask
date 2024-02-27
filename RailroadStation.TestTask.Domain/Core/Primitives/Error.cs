using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Domain.Core.Primitives
{
    /// <summary>
    /// Ошибка домена
    /// </summary>
    public class Error : ValueObject
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
