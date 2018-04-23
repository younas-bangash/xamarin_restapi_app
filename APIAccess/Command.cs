using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APIAccess
{
    internal class Command : ICommand
    {
        private Func<Task<object>> p;

        public Command(Func<Task<object>> p)
        {
            this.p = p;
        }
    }
}