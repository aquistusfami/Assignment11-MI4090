# Bài tập tuần 11 - OOP

### 1. Adapter nên kế thừa hay chứa `LegacySmokeDetector`?

- `Adapter` chứa lớp cũ vì lớp cũ là sealed, tránh lộ `SetSmokeLevel` ra ngoài, và luôn đọc giá trị hiện tại thay vì sao chép trạng thái.

### 2. `SensorMonitor` có nên biết `EmailAlertObserver` cụ thể không?

- `SensorMonitor` không nên biết `EmailAlertObserver`, chỉ cần biết `IAlertObserver`. nếu như muốn thêm các bên nhận mới thì chỉ cần viết lớp mới rồi `Attach` vào là được không phải sửa monitor.

### 3. `Alarm` có cần tham chiếu đến `DoorController` không?

- `Alarm` không cần tham chiếu `DoorController`. khi đổi quy trình phối hợp giữa các thiết bị chỉ cần sửa mediator, các thiết bị giữ nguyên và có thể dùng lại ở chỗ khác.

### 4. Ai chịu trách nhiệm quyết định giá trị nào là vượt ngưỡng?

- `SensorMonitor` quyết định ngưỡng. vì adapter chỉ giúp đổi đơn vị, observer thì phản ứng với severity đã set up, gom ngưỡng về `SensorMonitor` giúp việc đổi ngưỡng chỉ cần sửa ở 1 nơi.

 