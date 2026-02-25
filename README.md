<div align="center">

# 🎮 2D Character Controller
### State Machine · New Input System · Unity C#

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-10.0-239120?style=for-the-badge&logo=csharp)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Active-success?style=for-the-badge)

Чистая, расширяемая архитектура 2D-персонажа на основе конечного автомата состояний с поддержкой нового Input System от Unity.

[Архитектура](#-архитектура) · [Состояния](#-состояния) · [Установка](#-установка) · [Использование](#-использование)

</div>

---

## ✨ Особенности

- **Конечный автомат (FSM)** — чёткое разделение логики по состояниям без спагетти-кода
- **New Input System** — поддержка геймпадов, клавиатуры, тач-ввода из коробки
- **Расширяемость** — новое состояние добавляется за ~5 минут
- **Без зависимостей** — чистый C#, никаких сторонних пакетов

---

## 🏛 Архитектура

```
CharacterController2D
├── CharacterStateController
│   ├── CharacterState            ← абстрактный базовый класс
│   ├── NormalMovement            ← Класс передвижения        
│   ├── TestState                 ← Класс для проверки перехода между состояниями

├── CharacterActions             ← обёртка над New Input System
```

## 🧩 Состояния

| Состояние | Описание | Переходы |
|-----------|----------|----------|
| `NormalMovement` | Персонаж стоит на месте и передвижение | Idle, Move |
| `TestState` |  Тестовое состояние 

---

## 📦 Установка

### Требования
- Unity **2022.3 LTS** и выше
- Пакет `Input System` (установить через Package Manager)

### Шаги

1. Склонировать репозиторий или скопировать папку `Scripts/` в свой проект
```bash
git clone https://github.com/W-I-W/CharacterController2D.git
```

2. В **Project Settings → Player** переключить Active Input Handling на `Input System Package (New)`

---

## 🚀 Использование

### Добавить своё состояние

```csharp
public class NormalMovement : CharacterState
{
    [SerializeField] private MovementParameters m_Movement;

    private float m_CurrentSpeed = 0f;

    public override void OnUpdate(float dt)
    {
        float speed = (characterActions.movement.value.x * m_Movement.speedMovement * dt);
        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, speed, dt);
        characterActor.Movement(new Vector2(m_CurrentSpeed, 0));
    }
}
```

### Input Actions (New Input System)

```csharp
// CharacterActions.cs
    public void Init() - Инициализировать состояние ввода
    {
        movement = new Vector2Input(m_InputHandler.Player.Move); 
    }

    private void OnEnable() — подписка на события
    {
        movement.Enable();
    }

    private void OnDisable() Отписаться от события
    {
        movement.Disable();
    }
```

---

## 📁 Структура проекта

```
InternalAssets/
└── Scripts/
    ├── Character/
        ├── Actions/
        │   ├── CharacterActions.cs
        │   ├── Vector2Input.cs
        ├── Core/
        │   ├── CharacterActor.cs
        │   └── CharacterBrain.cs
        │   └── CharacterState.cs
        │   └── CharacterStateController.cs
        ├── States/
        │   ├── NormalMovement.cs
        │   ├── TestState.cs
    ├── Character/
    │   ├── GameManager.cs
```

## 📄 Лицензия

Распространяется под лицензией **MIT**. Подробнее — в файле [LICENSE](LICENSE).

---

<div align="center">
Сделано с ❤️ для Unity-разработчиков
</div>
