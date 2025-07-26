using System.Collections;
using UnityEngine;

namespace Niksan.CardGame
{
    public interface IFlippable
    {
        bool IsFlipped { get; }
        IEnumerator Flip(bool isFront);
    }
}
