using HX1584_HFT_2023241.Models;
using System.Collections.Generic;

namespace HX1584_HFT_2023241.Logic.Interface
{
    public interface ICartLogic
    {
        IEnumerable<Cart> CommentsByStatus(bool status);
        void Create(Cart item);
        void Delete(int id);
        IEnumerable<Cart> MultipleSame();
        Cart Read(int id);
        IEnumerable<Cart> ReadAll();
        void Update(Cart item);
    }
}