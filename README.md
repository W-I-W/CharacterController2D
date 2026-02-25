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

### Базовая настройка

```csharp
// CharacterData.cs — настройте через инспектор
[CreateAssetMenu(menuName = "Character/Data")]
public class CharacterData : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float acceleration = 10f;

    [Header("Jump")]
    public float jumpForce = 16f;
    public float coyoteTime = 0.15f;
    public float jumpBufferTime = 0.1f;

    [Header("Gravity")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
}
```

### Добавить своё состояние

```csharp
public class DashState : StateBase
{
    public DashState(StateMachine sm, CharacterController2D character)
        : base(sm, character) { }

    public override void Enter()
    {
        // запустить dash-логику
    }

    public override void Update()
    {
        // проверка завершения дэша → переход в Idle/Move
        if (dashComplete)
            StateMachine.ChangeState<IdleState>();
    }

    public override void Exit()
    {
        // сброс дэша
    }
}
```

### Input Actions (New Input System)

```csharp
// InputHandler.cs — подписка на события
private void OnEnable()
{
    _actions.Gameplay.Jump.performed += OnJump;
    _actions.Gameplay.Jump.canceled  += OnJumpCanceled;
    _actions.Gameplay.Enable();
}
```

---

## 📁 Структура проекта

```
Assets/
└── Scripts/
    ├── Character/
    │   ├── CharacterController2D.cs
    │   ├── CharacterData.cs
    │   └── InputHandler.cs
    ├── StateMachine/
    │   ├── StateMachine.cs
    │   ├── StateBase.cs
    │   └── States/
    │       ├── IdleState.cs
    │       ├── MoveState.cs
    │       ├── JumpState.cs
    │       ├── FallState.cs
    │       └── AttackState.cs
    └── Physics/
        └── PhysicsController.cs
```

---

## 🤝 Contributing

PR приветствуются! Для крупных изменений — сначала откройте Issue.

1. Fork репозитория
2. Создайте ветку: `git checkout -b feature/WallJump`
3. Commit: `git commit -m "Add wall jump state"`
4. Push: `git push origin feature/WallJump`
5. Откройте Pull Request

---

## 📄 Лицензия

Распространяется под лицензией **MIT**. Подробнее — в файле [LICENSE](LICENSE).

---

<div align="center">
Сделано с ❤️ для Unity-разработчиков
</div>
