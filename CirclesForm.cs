using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_laba3_1
{
    // Класс Form1 представляет основную форму приложения, которая управляет отображением и взаимодействием с кругами
    public partial class CirclesForm : Form
    {
        private readonly CircleContainer _container = new CircleContainer(); // Контейнер для хранения всех кругов
        private bool _isCtrlPressed; // Флаг, указывающий, нажата ли клавиша Ctrl

        public CirclesForm()
        {
            InitializeComponent();

            // Подписываемся на события формы для обработки различных действий пользователя
            this.Paint += CirclesForm_Paint; // Отрисовка кругов
            this.MouseDown += CirclesForm_MouseDown; // Обработка нажатия мыши
            this.MouseMove += CirclesForm_MouseMove; // Отслеживание движения мыши
            this.KeyDown += CirclesForm_KeyDown; // Обработка нажатия клавиш
            this.KeyUp += CirclesForm_KeyUp; // Обработка отпускания клавиш
            this.Resize += CirclesForm_Resize; // Обработка изменения размера формы

            // Инициализация текста для Label и Panel
            labelMouseCoordinates.Text = "Mouse: (0, 0)"; // Начальные координаты мыши
            UpdateCircleCoordinatesPanel(); // Обновление панели с координатами кругов
        }

        // Метод CirclesForm_Paint вызывается при необходимости перерисовки формы
        // Он отвечает за отрисовку всех кругов, хранящихся в контейнере
        private void CirclesForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var circle in _container.GetAll())
            {
                circle.Draw(e.Graphics); // Отрисовка каждого круга
            }
        }

        // Метод CirclesForm_MouseDown обрабатывает событие нажатия кнопки мыши
        // Если нажата левая кнопка, проверяется, попадает ли клик в какой-либо круг

        // Вариант 1: Выделяются все круги в точке клика
        // Если в точке клика находится несколько кругов, они все выделяются одновременно
        private void CirclesForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Находим все круги, которые содержат точку клика
                var clickedCircles = _container.GetAll()
                    .Where(circle => circle.Contains(e.Location))
                    .ToList();

                if (clickedCircles.Any())
                {
                    // Если Ctrl не нажат, снимаем выделение со всех кругов
                    if (!_isCtrlPressed)
                    {
                        _container.ClearSelection();
                    }

                    // Переключаем выделение для каждого круга из списка
                    foreach (var circle in clickedCircles)
                    {
                        circle.IsSelected = !circle.IsSelected;
                    }
                }
                else
                {
                    // Если ни один круг не был выбран, создаем новый круг
                    _container.Add(new CCircle(e.Location)); // Используем новый конструктор
                }

                // Обновляем панель с координатами кругов
                UpdateCircleCoordinatesPanel();

                // Перерисовываем форму
                Invalidate(); // Это важно для обновления отрисовки
            }
        }

        // Метод CirclesForm_MouseMove обновляет координаты мыши в реальном времени
        private void CirclesForm_MouseMove(object sender, MouseEventArgs e)
        {
            labelMouseCoordinates.Text = $"Mouse: ({e.X}, {e.Y})"; // Обновление текста с координатами мыши
        }

        // Метод CirclesForm_KeyDown обрабатывает нажатие клавиш
        // Если нажата клавиша Ctrl, устанавливается соответствующий флаг
        // Если нажата клавиша Delete, удаляются все выделенные круги
        private void CirclesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _isCtrlPressed = true; // Установка флага нажатия Ctrl
            }
            else if (e.KeyCode == Keys.Delete)
            {
                var selectedCircles = _container.GetAll().Where(c => c.IsSelected).ToList();
                foreach (var circle in selectedCircles)
                {
                    _container.Remove(circle); // Удаление выделенных кругов
                }
                UpdateCircleCoordinatesPanel(); // Обновление панели с координатами
                Invalidate(); // Перерисовка формы
            }
        }

        // Метод CirclesForm_KeyUp обрабатывает отпускание клавиш
        // Если отпущена клавиша Ctrl, сбрасывается соответствующий флаг
        private void CirclesForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _isCtrlPressed = false; // Сброс флага нажатия Ctrl
            }
        }

        // Метод CirclesForm_Resize вызывается при изменении размера формы
        // Он перерисовывает форму для корректного отображения кругов
        private void CirclesForm_Resize(object sender, EventArgs e)
        {
            Invalidate(); // Перерисовка формы
        }

        // Метод UpdateCircleCoordinatesPanel обновляет панель с координатами всех кругов
        // Для каждого круга выводятся его порядковый номер и координаты центра
        private void UpdateCircleCoordinatesPanel()
        {
            var text = string.Join(Environment.NewLine, _container.GetAll()
    .Select(circle => $"Circle {circle.Number}: ({circle.Center.X}, {circle.Center.Y})"));
            panelCircleCoordinates.Controls.Clear(); // Очистка панели
            panelCircleCoordinates.Controls.Add(new Label
            {
                Text = text, // Добавление текста с координатами
                AutoSize = true, // Автоматическое изменение размера текста
                Location = new Point(5, 5) // Позиция текста на панели
            });
        }
    }
}
