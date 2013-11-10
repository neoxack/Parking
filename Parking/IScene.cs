using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    //интерфейс сцены
    public interface IScene
    {
        void Update(double deltaTime); //метод обновления (deltaTime - время, прошедшее с момента последнего обновления)
        void Render(Graphics g);       //метод отрисовки
    }
}
