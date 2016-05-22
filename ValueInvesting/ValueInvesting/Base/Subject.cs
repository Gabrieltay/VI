using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Base
{
    public class Subject : Base
    {
        private List<Observer> mObserverList = new List<Observer>();

        public void Subscribe( Observer observer )
        {
            this.mObserverList.Add( observer );
        }

        public void Unsubscribe( Observer observer )
        {
            this.mObserverList.Remove( observer );
        }

        public void Notify( Action action, object subject = null )
        {
            foreach ( Observer observer in this.mObserverList )
                observer.update( action, subject );
        }
    }
}
