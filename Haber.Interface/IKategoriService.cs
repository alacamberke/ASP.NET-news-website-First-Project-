using Haber.Entities;
using Haber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Interface
{
    [ServiceContract]
    public interface IKategoriService
    {
        [OperationContract]
        List<Kategori> GetAllEntities();

        [OperationContract]
        List<KategoriModel> GetAll();

        [OperationContract]
        KategoriModel Get(int id);

        [OperationContract]
        void Add(KategoriModel kategori);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        KategoriModel Listing(Kategori kategori);

        [OperationContract]
        void Update(KategoriModel kategorimodel);
    }
}
