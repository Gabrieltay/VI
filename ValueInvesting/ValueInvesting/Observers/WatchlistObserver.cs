using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;
using ValueInvesting.Base;
using System.Collections;

namespace ValueInvesting.Observers
{
    public class WatchlistObserver : Observer
    {
        public WatchlistObserver(ObjectListView aOLV)
        {
            this.mOLV = aOLV;
        }

        public override void update( Action aAction, object aSubject )
        {
            switch ( aAction )
            {
                case Action.INSERT_OBJECT:
                    {
                        this.mOLV.AddObject( aSubject );
                        this.mOLV.BuildList( true );
                        break;
                    }
                case Action.INSERT_OBJECTS:
                    {
                        this.mOLV.AddObjects( (IList) aSubject );
                        break;
                    }
                case Action.UPDATE_OBJECT:
                    {
                        this.mOLV.RefreshObject( aSubject );
                        break;
                    }
                case Action.UPDATE_OBJECTS:
                    {
                        this.mOLV.ClearObjects();
                        this.mOLV.AddObjects( (IList) aSubject );
                        break;
                    }
                case Action.DELETE_OBJECT:
                    {
                        this.mOLV.RemoveObject( aSubject );
                        break;
                    }
                case Action.DELETE_OBJECTS:
                    {
                        this.mOLV.RemoveObjects( (IList) aSubject );
                        break;
                    }
                case Action.CLEAR_OBJECTS:
                    {
                        this.mOLV.ClearObjects();
                        break;
                    }
                default:
                    break;
            }
        }

        private ObjectListView mOLV
        {
            get; set;
        }
    }
}
