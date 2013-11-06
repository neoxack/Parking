using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public interface IScene
    {
        void Update(double deltaTime);
        void Render(Graphics g);
    }
}
