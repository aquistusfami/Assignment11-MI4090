# Bài tập tuần 11 - OOP
> [!NOTE]
> draft. not fully yet.
### 1. Adapter nên kế thừa hay chứa `LegacySmokeDetector`? 
- `Adapter` chứa lớp cũ, vì lớp cũ là sealed và cần composition
### 2. `SensorMonitor` có nên biết `EmailAlertObserver` cụ thể không? 
- `SensorMonitor` không nên biết `EmailAlertObserver`, chỉ cần biết `IAlertObserver`.
### 3. `Alarm` có cần tham chiếu đến `DoorController` không? 
- `Alarm` không cần tham chiếu `DoorController`.
### 4. Ai chịu trách nhiệm quyết định giá trị nào là vượt ngưỡng? 
- `SensorMonitor` quyết định ngưỡng.
