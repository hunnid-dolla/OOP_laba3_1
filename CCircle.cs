using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba3_1
{
    // Класс CCircle представляет собой круг с фиксированным радиусом, который может быть отрисован на графической поверхности
    // Он также поддерживает выделение и отображение порядкового номера
    public class CCircle
    {
        private const int Radius = 30; // Постоянный радиус круга (30 пикселей)
        public Point Center { get; private set; } // Центр круга (точка с координатами X и Y)
        public bool IsSelected { get; set; } // Флаг, указывающий, выделен ли круг
        public int Number { get; set; } // Порядковый номер круга

        // Глобальный счетчик для генерации уникальных номеров
        private static int NextNumber = 1;

        // Конструктор класса CCircle инициализирует центр круга, устанавливает флаг выделения в false
        // и задает порядковый номер круга с использованием глобального счетчика
        public CCircle(Point center)
        {
            Center = center;
            IsSelected = false;
            Number = NextNumber++; // Присваиваем номер и увеличиваем счетчик
        }

        // Метод Contains проверяет, находится ли указанная точка внутри круга
        public bool Contains(Point point)
        {
            int dx = point.X - Center.X; // Разница по оси X между точкой и центром круга
            int dy = point.Y - Center.Y; // Разница по оси Y между точкой и центром круга
            return dx * dx + dy * dy <= Radius * Radius; // Проверка по теореме Пифагора
        }

        // Метод Draw отвечает за отрисовку круга на графической поверхности
        public void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(IsSelected ? Color.DeepPink : Color.Purple)) // Заливка: розовая для выделенного, фиолетовая для невыделенного
            using (var pen = new Pen(Color.Black, 2)) // Черная обводка толщиной 2 пикселя
            {
                // Рисуем круг с использованием метода FillEllipse (заливка) и DrawEllipse (обводка)
                g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

                // Создаем шрифт для отображения номера круга
                var font = new Font("Arial", 10, FontStyle.Bold);

                // Вычисляем размер текста с номером круга для его центрирования
                var textSize = g.MeasureString(Number.ToString(), font);
                var textX = Center.X - textSize.Width / 2; // Горизонтальное центрирование текста
                var textY = Center.Y - textSize.Height / 2; // Вертикальное центрирование текста

                // Отрисовываем номер круга черным цветом в центре круга
                g.DrawString(Number.ToString(), font, Brushes.Black, textX, textY);
            }
        }
    }
}
