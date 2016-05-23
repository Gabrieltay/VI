using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Base;
using ValueInvesting.Models;

namespace ValueInvesting.Controllers
{
    public class WatchlistController : Singleton<WatchlistController>
    {
        public void Init()
        {
            this.Init( new DataModel<Stock>() );
        }

        public void Init( DataModel<Stock> aModel )
        {
            this.StockModel = aModel;
        }

        public void Add( Stock aStock )
        {
            if ( isExist( aStock ) )
            {
                this.StockModel.Remove( GetStock( aStock.Sym, aStock.Mkt ) );
            }

            this.StockModel.Add( aStock );
        }

        public void Add( List<Stock> aStockList )
        {
            this.StockModel.Add( aStockList );
        }

        public void Edit( Stock aStock )
        {
            this.StockModel.Edit( aStock );
        }

        public void Delete(Stock aStock)
        {
            this.StockModel.Remove( aStock );
        }

        public void Delete( ArrayList aDeleteList )
        {
            this.StockModel.Remove( aDeleteList );
        }

        public void Clear()
        {
            this.StockModel.Clear();
        }

        public Boolean isExist(Stock aStock)
        {
            foreach ( Stock nStock in this.StockModel.GetList() )
            {
                if ( nStock.Sym == aStock.Sym && nStock.Mkt == aStock.Mkt )
                    return true;
            }
            return false;
        }

        public Boolean isExist(String aSymbol)
        {
            foreach ( Stock nStock in this.StockModel.GetList() )
            {
                if ( nStock.Sym == aSymbol )
                    return true;
            }
            return false;
        }

        public Stock GetStock(String aSymbol)
        {
            foreach ( Stock nStock in this.StockModel.GetList() )
            {
                if ( nStock.Sym == aSymbol )
                    return nStock;
            }
            return null;
        }

        public Stock GetStock(String aSymbol, String aMarket)
        {
            foreach ( Stock nStock in this.StockModel.GetList() )
            {
                if ( nStock.Sym == aSymbol && nStock.Mkt == aMarket )
                    return nStock;
            }
            return null;
        }

        public void Subscribe(Observer aObserver)
        {
            this.StockModel.Subscribe( aObserver );
        }

        public void Unsubscribe(Observer aObserver)
        {
            this.StockModel.Unsubscribe( aObserver );
        }

        public DataModel<Stock> GetModel()
        {
            return this.StockModel;
        }

        #region Properties
        private DataModel<Stock> StockModel
        {
            get;
            set;
        }
        #endregion
    }
}
