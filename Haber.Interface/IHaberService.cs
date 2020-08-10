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
    public interface IHaberService
    {
        [OperationContract]
        List<HaberModel> GetAll();

        [OperationContract]
        HaberModel Get(int id);

        [OperationContract]
        void Add(HaberModel haber);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        List<HaberModel> Listing(KategoriModel kategorimodel);

        [OperationContract]
        HaberModel View(HaberModel haber);

    }
}
