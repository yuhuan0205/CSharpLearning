# GitLab CI/CD 筆記
## CI/CD
利用腳本自動化建構、測試、交付、部署。
## GitLab
一個開源的服務，提供開發者方便進行CI/CD的平台，可以將服務架設在本地端上。
## 概念及架構
* Pipeline：為一 CI/CD 中的所有流程。
* Stage：Pipeline中依據不同的Stage決定其執行順序。
* Job：Runner 分派給 Executor 來執行的單位任務，JobS間沒有執行順序。
* Runner：一個服務，分派 Job 給 Executor 去執行。
* Executor：真正執行 Job 的單位，可以是本機的Shell、Docker、K8s...
* .gitlab-ci.yml：定義 Pipeline 的文件。