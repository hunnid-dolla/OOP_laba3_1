using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba3_1
{
    // Класс CircleContainer представляет собой контейнер для хранения объектов типа CCircle
    // Он предоставляет методы для управления коллекцией кругов, включая добавление, удаление,
    // получение всех кругов и очистку выделения
    public class CircleContainer
    {
        // Поле _circles представляет собой список, который хранит все добавленные круги
        private readonly List<CCircle> _circles = new List<CCircle>();

        // Метод Add добавляет новый круг в контейнер
        // Параметр circle представляет собой объект типа CCircle, который нужно добавить
        public void Add(CCircle circle)
        {
            _circles.Add(circle);
        }

        // Метод Remove удаляет указанный круг из контейнера
        // Параметр circle представляет собой объект типа CCircle, который нужно удалить
        // Если круг не найден в списке, метод не выполнит никаких действий
        public void Remove(CCircle circle)
        {
            _circles.Remove(circle);
        }

        // Метод GetAll возвращает коллекцию всех кругов, содержащихся в контейнере
        // Возвращаемое значение представляет собой IEnumerable<CCircle>, что позволяет
        // перебирать круги без прямого доступа к внутреннему списку
        public IEnumerable<CCircle> GetAll()
        {
            return _circles;
        }

        // Метод ClearSelection снимает выделение со всех кругов в контейнере
        // Это достигается путем установки свойства IsSelected каждого круга в false
        public void ClearSelection()
        {
            foreach (var circle in _circles)
            {
                circle.IsSelected = false; // Снимаем выделение
            }
        }
    }
}