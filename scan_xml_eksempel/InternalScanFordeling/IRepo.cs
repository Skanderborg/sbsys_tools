using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForBarcode.DAL
{
	public interface IRepo<IEntity>
	{
		IEnumerable<IEntity> List { get; }
		void Add(IEntity entity);
		void Update(IEntity entity);
		void Delete(IEntity entity);
		IEntity FindById(int id);
	}
}
