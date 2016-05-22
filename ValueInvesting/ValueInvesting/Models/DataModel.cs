using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Base;

namespace ValueInvesting.Models
{
    public class DataModel<T> : Subject
    {
        public DataModel()
        {
            this.Model = new List<T>();
        }

        public DataModel(List<T> aModel )
        {
            this.Model = aModel;
            Notify( Action.CLEAR_OBJECTS );
            Notify( Action.INSERT_OBJECTS, this.Model );
        }

        public void Add( T aObj )
        {
            this.Model.Add( aObj );
            Notify( Action.INSERT_OBJECT, aObj );
        }

        public void Add( List<T> aObjList )
        {
            this.Add( aObjList, false );
        }

        public void Add( IEnumerable aObjList, bool aOverwrite )
        {
            if ( aOverwrite )
            {
                this.Model = (List<T>) ( aObjList );
                Notify( Action.UPDATE_OBJECTS, this.Model );
            }
            else
            {
                this.Model.AddRange( ( aObjList.OfType<T>() ) );
                Notify( Action.INSERT_OBJECTS, aObjList );
            }
        }

        public void Edit( T aObj )
        {
            Notify( Action.UPDATE_OBJECT, aObj );
        }

        public void Remove( T aObj )
        {
            this.Model.Remove( aObj );
            Notify( Action.DELETE_OBJECT, aObj );
        }

        public void Remove( ArrayList aDeleteList )
        {
            foreach ( T nDelObj in aDeleteList )
            {
                int objIndex = this.Model.IndexOf( nDelObj );
                if ( objIndex >= 0 )
                    this.Model.RemoveAt( objIndex );
            }
            Notify( Action.DELETE_OBJECTS, aDeleteList );
        }

        public void Clear()
        {
            this.Model.Clear();
            Notify( Action.CLEAR_OBJECTS );
        }

        public int Size()
        {
            return this.Model.Count;
        }

        public List<T> GetList()
        {
            return this.Model;
        }

        #region Properties
        private List<T> Model
        {
            get;
            set;
        }
        #endregion
    }
}
