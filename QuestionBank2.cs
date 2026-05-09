using System.Collections.Generic;

namespace AzureExamQuestions
{
    // ============================================================
    //  ВТОРОЙ БАНК ВОПРОСОВ AZ-900  (ID 121–240)
    //  Сгенерирован как дополнение к QuestionBank.cs.
    //  Охватывает темы, слабо представленные в первом банке:
    //   · ИИ / ML сервисы и интеграция данных
    //   · Идентификация, безопасность, соответствие требованиям
    //   · Хранилище (тарифные планы, избыточность, Private Link)
    //   · Управление затратами и ресурсами (детали)
    //   · Аварийное восстановление, резервное копирование, миграция
    //   · Сложные экзаменационные сценарии
    // ============================================================
    public static class QuestionBank2
    {
        public static List<Question> GetAdditionalQuestions()
        {
            return new List<Question>
            {
                // ==================== БЛОК 7 (121–140) — ИИ, данные, интеграция ====================

                // Q121 — Azure Cognitive Services vs. Azure Machine Learning: классический вопрос AZ-900
                new Question
                {
                    Id = 121,
                    Text = "A developer wants to add speech-to-text and language translation capabilities to an application WITHOUT training custom machine learning models. Which Azure service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure Machine Learning",
                        "B) Azure Cognitive Services (Azure AI Services)",
                        "C) Azure Databricks",
                        "D) Azure Bot Service"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Cognitive Services (Azure AI Services)",
                    Difficulty = 1
                },

                // Q122 — Azure Bot Service: создание разговорных агентов
                new Question
                {
                    Id = 122,
                    Text = "Which Azure service provides a managed environment for building, testing, and deploying intelligent chatbots that can interact with users through multiple channels such as Teams, web chat, and SMS?",
                    Options = new List<string>
                    {
                        "A) Azure Logic Apps",
                        "B) Azure Cognitive Services",
                        "C) Azure Bot Service",
                        "D) Azure Notification Hubs"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Bot Service",
                    Difficulty = 1
                },

                // Q123 — Azure Data Factory: ETL/ELT-сервис
                new Question
                {
                    Id = 123,
                    Text = "A company needs to ingest data from multiple on-premises databases and cloud sources, transform it, and load it into an Azure data warehouse on a scheduled basis. Which Azure service is specifically designed for this Extract-Transform-Load (ETL) / Extract-Load-Transform (ELT) pipeline scenario?",
                    Options = new List<string>
                    {
                        "A) Azure Stream Analytics",
                        "B) Azure Data Factory",
                        "C) Azure Service Bus",
                        "D) Azure Databricks"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Data Factory",
                    Difficulty = 2
                },

                // Q124 — Azure Synapse Analytics: единая аналитическая платформа
                new Question
                {
                    Id = 124,
                    Text = "Which Azure service provides a unified analytics platform that combines big data processing (Apache Spark), enterprise data warehousing, and data integration capabilities in a single service?",
                    Options = new List<string>
                    {
                        "A) Azure HDInsight",
                        "B) Azure Data Lake Storage Gen2",
                        "C) Azure Synapse Analytics",
                        "D) Azure Analysis Services"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Synapse Analytics",
                    Difficulty = 2
                },

                // Q125 — Azure Event Hubs: большие потоки событий / телеметрия
                new Question
                {
                    Id = 125,
                    Text = "A company needs to ingest millions of events per second from web applications, mobile apps, and IoT devices for real-time analytics and archiving. Which Azure messaging service is optimized for high-throughput event streaming at this scale?",
                    Options = new List<string>
                    {
                        "A) Azure Service Bus",
                        "B) Azure Queue Storage",
                        "C) Azure Event Grid",
                        "D) Azure Event Hubs"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Azure Event Hubs",
                    Difficulty = 2
                },

                // Q126 — Azure Event Grid vs. Service Bus: реактивная маршрутизация событий
                new Question
                {
                    Id = 126,
                    Text = "Which Azure messaging service uses a publish-subscribe model to route *discrete events* (e.g., 'blob created', 'resource deleted') to multiple subscribers, and is optimized for reactive, event-driven architectures rather than ordered message delivery?",
                    Options = new List<string>
                    {
                        "A) Azure Service Bus",
                        "B) Azure Event Hubs",
                        "C) Azure Event Grid",
                        "D) Azure Notification Hubs"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Event Grid",
                    Difficulty = 3
                },

                // Q127 — Azure Service Bus: enterprise messaging
                new Question
                {
                    Id = 127,
                    Text = "Which Azure messaging service is best suited for enterprise messaging scenarios that require guaranteed message delivery, message ordering, dead-lettering, and transactions across microservices?",
                    Options = new List<string>
                    {
                        "A) Azure Event Hubs",
                        "B) Azure Event Grid",
                        "C) Azure Queue Storage",
                        "D) Azure Service Bus"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Azure Service Bus",
                    Difficulty = 2
                },

                // Q128 — Azure Logic Apps: low-code workflow automation
                new Question
                {
                    Id = 128,
                    Text = "A business analyst (non-developer) needs to create an automated workflow that runs every morning, pulls sales data from Salesforce, formats it, and sends a summary email via Office 365. Which Azure service allows this with a visual, low-code designer?",
                    Options = new List<string>
                    {
                        "A) Azure Functions",
                        "B) Azure Logic Apps",
                        "C) Azure Data Factory",
                        "D) Azure Automation"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Logic Apps",
                    Difficulty = 2
                },

                // Q129 — Azure Databricks: совместная аналитика на Apache Spark
                new Question
                {
                    Id = 129,
                    Text = "A data science team needs a collaborative Apache Spark-based analytics platform for exploratory data analysis, machine learning model development, and large-scale data engineering workloads. Which Azure service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure Machine Learning Studio (classic)",
                        "B) Azure HDInsight",
                        "C) Azure Databricks",
                        "D) Azure Data Factory"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Databricks",
                    Difficulty = 3
                },

                // Q130 — Azure AI Search (Cognitive Search)
                new Question
                {
                    Id = 130,
                    Text = "A company wants to add full-text search, AI-powered enrichment (e.g., key phrase extraction, image OCR), and faceted navigation to their e-commerce website using content from Blob Storage and Azure SQL. Which Azure service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure Cognitive Services",
                        "B) Azure AI Search (Azure Cognitive Search)",
                        "C) Azure Synapse Analytics",
                        "D) Azure Cache for Redis"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure AI Search (Azure Cognitive Search)",
                    Difficulty = 3
                },

                // Q131 — Azure API Management
                new Question
                {
                    Id = 131,
                    Text = "Which Azure service acts as a gateway between API consumers and backend services, providing features such as rate limiting, authentication, caching, and a developer portal for API documentation?",
                    Options = new List<string>
                    {
                        "A) Azure Application Gateway",
                        "B) Azure Front Door",
                        "C) Azure API Management",
                        "D) Azure Logic Apps"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure API Management",
                    Difficulty = 2
                },

                // Q132 — Azure OpenAI Service
                new Question
                {
                    Id = 132,
                    Text = "A company wants to integrate large language models (LLMs) such as GPT-4 into their enterprise applications with the security, compliance, and regional availability of Azure. Which service provides access to these models via a managed Azure endpoint?",
                    Options = new List<string>
                    {
                        "A) Azure Machine Learning",
                        "B) Azure Cognitive Services Language",
                        "C) Azure OpenAI Service",
                        "D) Azure Databricks ML Runtime"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure OpenAI Service",
                    Difficulty = 1
                },

                // Q133 — Azure Queue Storage vs. Service Bus: когда использовать Queue
                new Question
                {
                    Id = 133,
                    Text = "You need a simple, low-cost message queue that allows decoupling of application components and can store millions of messages (up to 64 KB each) for asynchronous processing. Advanced features like dead-letter queues or message ordering are NOT required. Which service is most appropriate?",
                    Options = new List<string>
                    {
                        "A) Azure Service Bus",
                        "B) Azure Event Grid",
                        "C) Azure Queue Storage",
                        "D) Azure Event Hubs"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Queue Storage",
                    Difficulty = 2
                },

                // Q134 — Azure IoT Central: managed IoT platform (SaaS)
                new Question
                {
                    Id = 134,
                    Text = "Which Azure IoT service provides a fully managed, SaaS-based IoT application platform with built-in dashboards and device management, allowing companies to deploy an IoT solution WITHOUT building or managing cloud infrastructure?",
                    Options = new List<string>
                    {
                        "A) Azure IoT Hub",
                        "B) Azure IoT Central",
                        "C) Azure Sphere",
                        "D) Azure Digital Twins"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure IoT Central",
                    Difficulty = 2
                },

                // Q135 — Azure Sphere: IoT device security
                new Question
                {
                    Id = 135,
                    Text = "Which Azure IoT service is a comprehensive security solution for microcontroller-based IoT devices, providing a secured hardware chip (MCU), a custom Linux OS, and a cloud-based security service to protect devices from end to end?",
                    Options = new List<string>
                    {
                        "A) Azure IoT Hub",
                        "B) Azure IoT Central",
                        "C) Azure Sphere",
                        "D) Azure RTOS"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Sphere",
                    Difficulty = 2
                },

                // Q136 — Azure Digital Twins: моделирование физической среды
                new Question
                {
                    Id = 136,
                    Text = "A smart building company wants to create a real-time digital model of a physical building — including rooms, HVAC systems, and occupancy sensors — to simulate and optimize energy usage. Which Azure service enables this?",
                    Options = new List<string>
                    {
                        "A) Azure IoT Hub",
                        "B) Azure Maps",
                        "C) Azure Digital Twins",
                        "D) Azure Time Series Insights"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Digital Twins",
                    Difficulty = 3
                },

                // Q137 — Microsoft Purview: управление данными
                new Question
                {
                    Id = 137,
                    Text = "Which Microsoft service provides unified data governance, allowing organizations to discover, classify, and manage sensitive data across Azure, on-premises, and multi-cloud environments from a single pane of glass?",
                    Options = new List<string>
                    {
                        "A) Azure Policy",
                        "B) Microsoft Purview",
                        "C) Azure Information Protection",
                        "D) Azure Monitor"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Microsoft Purview",
                    Difficulty = 2
                },

                // Q138 — HDInsight: managed open-source Hadoop/Spark/Kafka
                new Question
                {
                    Id = 138,
                    Text = "Which Azure service provides fully managed clusters for open-source analytics frameworks like Hadoop, Spark, Kafka, HBase, and Hive, without requiring customers to manage the underlying infrastructure?",
                    Options = new List<string>
                    {
                        "A) Azure Databricks",
                        "B) Azure Synapse Analytics",
                        "C) Azure HDInsight",
                        "D) Azure Data Factory"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure HDInsight",
                    Difficulty = 3
                },

                // Q139 — Logic Apps vs. Functions: когда выбирать Logic Apps
                new Question
                {
                    Id = 139,
                    Text = "Which statement BEST describes when Azure Logic Apps is preferred over Azure Functions for workflow automation?",
                    Options = new List<string>
                    {
                        "A) When the workflow requires complex custom code algorithms written in C# or Python.",
                        "B) When the workflow needs to integrate many different SaaS connectors (like SAP, Salesforce, SharePoint) with minimal coding using a visual designer.",
                        "C) When sub-millisecond response time is required.",
                        "D) When the workflow needs to process hundreds of thousands of events per second."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) When the workflow needs to integrate many different SaaS connectors (like SAP, Salesforce, SharePoint) with minimal coding using a visual designer.",
                    Difficulty = 3
                },

                // Q140 — Azure Maps: геопространственные сервисы
                new Question
                {
                    Id = 140,
                    Text = "Which Azure service provides geospatial APIs and SDKs for adding maps, routing, traffic data, weather, and geocoding capabilities to applications?",
                    Options = new List<string>
                    {
                        "A) Azure Spatial Anchors",
                        "B) Azure Maps",
                        "C) Azure Digital Twins",
                        "D) Azure Remote Rendering"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Maps",
                    Difficulty = 1
                },

                // ==================== БЛОК 8 (141–160) — Идентификация, безопасность, соответствие ====================

                // Q141 — Conditional Access: применение условий для MFA
                new Question
                {
                    Id = 141,
                    Text = "A company wants to enforce Multi-Factor Authentication (MFA) only when users sign in from outside the corporate network or from an unmanaged device. Which Azure AD feature enables this policy-based access control?",
                    Options = new List<string>
                    {
                        "A) Azure AD Password Protection",
                        "B) Azure AD Conditional Access",
                        "C) Azure AD Identity Protection",
                        "D) Azure Role-Based Access Control (RBAC)"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure AD Conditional Access",
                    Difficulty = 2
                },

                // Q142 — Privileged Identity Management (PIM)
                new Question
                {
                    Id = 142,
                    Text = "A company needs to ensure that Global Administrator access is granted only when needed, requires justification, and is time-limited to minimize standing privilege. Which Azure AD feature should they implement?",
                    Options = new List<string>
                    {
                        "A) Azure AD Conditional Access",
                        "B) Azure RBAC with custom roles",
                        "C) Azure AD Privileged Identity Management (PIM)",
                        "D) Resource Locks"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure AD Privileged Identity Management (PIM)",
                    Difficulty = 3
                },

                // Q143 — Azure AD B2C: внешние клиенты / потребители
                new Question
                {
                    Id = 143,
                    Text = "A retail company is building a customer-facing mobile application and needs to allow customers to sign in using their existing Google, Facebook, or email accounts. Which Azure AD feature or service is designed for this *external consumer identity* scenario?",
                    Options = new List<string>
                    {
                        "A) Azure AD B2B (Business-to-Business)",
                        "B) Azure AD B2C (Business-to-Consumer)",
                        "C) Azure AD Connect",
                        "D) Azure AD Domain Services"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure AD B2C (Business-to-Consumer)",
                    Difficulty = 2
                },

                // Q144 — Azure AD B2B: совместная работа с внешними партнёрами
                new Question
                {
                    Id = 144,
                    Text = "Company A wants to share an internal Azure-hosted application with employees from Company B (a business partner), allowing them to use their own Company B credentials. Which Azure AD capability supports this *guest user collaboration* scenario?",
                    Options = new List<string>
                    {
                        "A) Azure AD B2C",
                        "B) Azure AD B2B Collaboration",
                        "C) Azure AD Connect",
                        "D) Azure AD Conditional Access"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure AD B2B Collaboration",
                    Difficulty = 2
                },

                // Q145 — Managed Identity: отсутствие credentials в коде
                new Question
                {
                    Id = 145,
                    Text = "An Azure Virtual Machine needs to access Azure Key Vault secrets without storing any credentials (service principal secrets or certificates) in the application code or configuration files. Which Azure feature eliminates the need for stored credentials?",
                    Options = new List<string>
                    {
                        "A) Azure AD Conditional Access",
                        "B) Azure Managed Identity",
                        "C) Azure Key Vault access policies",
                        "D) Azure RBAC custom role"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Managed Identity",
                    Difficulty = 2
                },

                // Q146 — Microsoft Sentinel: SIEM + SOAR
                new Question
                {
                    Id = 146,
                    Text = "Which Azure service is a cloud-native Security Information and Event Management (SIEM) and Security Orchestration Automated Response (SOAR) solution that collects security data at cloud scale, detects threats, and enables automated responses?",
                    Options = new List<string>
                    {
                        "A) Microsoft Defender for Cloud",
                        "B) Azure Monitor",
                        "C) Microsoft Sentinel",
                        "D) Azure Policy"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Microsoft Sentinel",
                    Difficulty = 2
                },

                // Q147 — Defender for Cloud vs. Sentinel: разница
                new Question
                {
                    Id = 147,
                    Text = "What is the PRIMARY difference between Microsoft Defender for Cloud and Microsoft Sentinel?",
                    Options = new List<string>
                    {
                        "A) Defender for Cloud focuses on Azure resources only; Sentinel focuses on multi-cloud.",
                        "B) Defender for Cloud provides security posture management and threat protection for Azure workloads; Sentinel is a SIEM/SOAR that aggregates security signals from many sources for broader threat detection and response.",
                        "C) Defender for Cloud is free; Sentinel requires a paid plan.",
                        "D) Sentinel cannot ingest logs from non-Microsoft sources."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Defender for Cloud provides security posture management and threat protection for Azure workloads; Sentinel is a SIEM/SOAR that aggregates security signals from many sources for broader threat detection and response.",
                    Difficulty = 3
                },

                // Q148 — Zero Trust: принципы
                new Question
                {
                    Id = 148,
                    Text = "Which principle is a core element of the Zero Trust security model?",
                    Options = new List<string>
                    {
                        "A) Trust all traffic originating from inside the corporate network perimeter.",
                        "B) Verify explicitly — always authenticate and authorize based on all available data points, regardless of location.",
                        "C) Grant the highest level of access by default to reduce friction for users.",
                        "D) Use a single, shared credential for all application services to simplify management."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Verify explicitly — always authenticate and authorize based on all available data points, regardless of location.",
                    Difficulty = 2
                },

                // Q149 — Azure AD Identity Protection
                new Question
                {
                    Id = 149,
                    Text = "Which Azure AD feature automatically detects suspicious sign-in behaviors (e.g., impossible travel, anonymous IP address usage, leaked credentials) and can automatically enforce remediation actions such as requiring MFA or blocking access?",
                    Options = new List<string>
                    {
                        "A) Azure AD Conditional Access",
                        "B) Azure AD Privileged Identity Management (PIM)",
                        "C) Azure AD Identity Protection",
                        "D) Microsoft Defender for Cloud"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure AD Identity Protection",
                    Difficulty = 3
                },

                // Q150 — Microsoft Privacy Statement: что это
                new Question
                {
                    Id = 150,
                    Text = "Which document from Microsoft describes how Microsoft collects, uses, and protects personal data across all its services, products, websites, and apps — including data collected from users of Azure, Office 365, and Bing?",
                    Options = new List<string>
                    {
                        "A) The Azure Service Level Agreement (SLA)",
                        "B) The Online Services Terms (OST)",
                        "C) The Microsoft Privacy Statement",
                        "D) The Azure Trust Center whitepaper"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) The Microsoft Privacy Statement",
                    Difficulty = 1
                },

                // Q151 — Online Services Terms (OST) / Data Protection Addendum (DPA)
                new Question
                {
                    Id = 151,
                    Text = "Which Microsoft document defines the legal terms and conditions (privacy, security, compliance commitments) that apply to the use of Microsoft's online services — such as Azure, Microsoft 365, and Dynamics 365 — and includes Microsoft's data protection commitments to customers?",
                    Options = new List<string>
                    {
                        "A) The Microsoft Privacy Statement",
                        "B) The Online Services Terms (OST) / Product Terms",
                        "C) The Azure Pricing Guide",
                        "D) The Azure Compliance Manager assessment"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) The Online Services Terms (OST) / Product Terms",
                    Difficulty = 2
                },

                // Q152 — Defense in Depth: концепция многоуровневой защиты
                new Question
                {
                    Id = 152,
                    Text = "Which security strategy uses a layered approach where multiple security controls are placed throughout the IT environment so that if one layer fails, additional layers continue to protect the data?",
                    Options = new List<string>
                    {
                        "A) Zero Trust",
                        "B) Perimeter security",
                        "C) Defense in Depth",
                        "D) Least Privilege"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Defense in Depth",
                    Difficulty = 1
                },

                // Q153 — Azure AD Password Protection
                new Question
                {
                    Id = 153,
                    Text = "Which Azure AD security feature prevents users from setting passwords that contain common words (like 'Password' or company name) and can also be extended to enforce the same policies for on-premises Active Directory?",
                    Options = new List<string>
                    {
                        "A) Multi-Factor Authentication (MFA)",
                        "B) Conditional Access policy with sign-in risk",
                        "C) Azure AD Password Protection",
                        "D) Azure AD Identity Protection"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure AD Password Protection",
                    Difficulty = 2
                },

                // Q154 — Microsoft Compliance Manager / Compliance Score
                new Question
                {
                    Id = 154,
                    Text = "Which tool in the Microsoft compliance portal provides a risk-based compliance score and helps organizations assess and improve their compliance posture against regulations such as GDPR, ISO 27001, and HIPAA?",
                    Options = new List<string>
                    {
                        "A) Azure Security Center Regulatory Compliance",
                        "B) Microsoft Compliance Manager",
                        "C) Service Trust Portal",
                        "D) Azure Policy compliance dashboard"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Microsoft Compliance Manager",
                    Difficulty = 3
                },

                // Q155 — Least Privilege в RBAC: принцип
                new Question
                {
                    Id = 155,
                    Text = "A security administrator must grant a new team member only enough permissions to perform their specific job tasks — nothing more. Which security principle does this represent?",
                    Options = new List<string>
                    {
                        "A) Defense in Depth",
                        "B) Zero Trust",
                        "C) Principle of Least Privilege",
                        "D) Separation of Duties"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Principle of Least Privilege",
                    Difficulty = 1
                },

                // Q156 — Azure AD Connect: синхронизация on-prem → cloud
                new Question
                {
                    Id = 156,
                    Text = "A company has on-premises Active Directory and wants to synchronize user identities to Azure AD so that employees can sign in to cloud services with the same username and password they use on-premises. Which tool performs this synchronization?",
                    Options = new List<string>
                    {
                        "A) Azure AD Domain Services",
                        "B) Azure AD B2B Collaboration",
                        "C) Azure AD Connect",
                        "D) Azure ExpressRoute"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure AD Connect",
                    Difficulty = 1
                },

                // Q157 — Azure AD Domain Services: managed domain controller
                new Question
                {
                    Id = 157,
                    Text = "A company is running legacy applications in Azure VMs that require domain join, Group Policy, and LDAP/Kerberos/NTLM authentication, but they do NOT want to deploy and manage their own Windows Server domain controllers in Azure. Which service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure AD Connect",
                        "B) Azure Active Directory (Azure AD)",
                        "C) Azure AD Domain Services",
                        "D) Azure Bastion"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure AD Domain Services",
                    Difficulty = 3
                },

                // Q158 — Just-in-time VM access (Defender for Cloud)
                new Question
                {
                    Id = 158,
                    Text = "Which feature in Microsoft Defender for Cloud reduces the attack surface of Azure Virtual Machines by locking down inbound traffic to management ports (like RDP port 3389 and SSH port 22) and only opening them for a limited time when explicitly requested?",
                    Options = new List<string>
                    {
                        "A) Azure Bastion",
                        "B) Network Security Groups with deny-all rules",
                        "C) Just-in-Time (JIT) VM access",
                        "D) Azure Firewall with FQDN filtering"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Just-in-Time (JIT) VM access",
                    Difficulty = 3
                },

                // Q159 — MFA: методы подтверждения
                new Question
                {
                    Id = 159,
                    Text = "Multi-Factor Authentication (MFA) requires users to verify their identity using at least two of which categories of verification?",
                    Options = new List<string>
                    {
                        "A) Something you know, something you have, and something you are.",
                        "B) Username, password, and employee ID.",
                        "C) IP address, device type, and location.",
                        "D) Email address, phone number, and security question."
                    },
                    CorrectAnswer = "A",
                    CorrectAnswerText = "A) Something you know, something you have, and something you are.",
                    Difficulty = 1
                },

                // Q160 — Azure Bastion: безопасный RDP/SSH без public IP
                new Question
                {
                    Id = 160,
                    Text = "You need to allow administrators to securely connect to Azure Virtual Machines via RDP and SSH directly from the Azure portal, without exposing the VMs to the public internet or requiring a VPN. Which Azure service provides this capability?",
                    Options = new List<string>
                    {
                        "A) Azure VPN Gateway",
                        "B) Azure Firewall",
                        "C) Azure Bastion",
                        "D) Azure Application Gateway"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Bastion",
                    Difficulty = 2
                },

                // ==================== БЛОК 9 (161–180) — Хранилище и сети (продвинутые) ====================

                // Q161 — Blob Storage тарифы: Hot/Cool/Cold/Archive
                new Question
                {
                    Id = 161,
                    Text = "A company stores compliance log files in Azure Blob Storage. These files are accessed frequently during the first 30 days after creation, then rarely accessed, and must be kept for 7 years. Which storage access tier is most cost-effective for files older than 30 days that are rarely accessed?",
                    Options = new List<string>
                    {
                        "A) Hot tier",
                        "B) Cool tier",
                        "C) Archive tier",
                        "D) Premium tier"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Archive tier",
                    Difficulty = 2
                },

                // Q162 — LRS vs. ZRS vs. GRS: когда что использовать
                new Question
                {
                    Id = 162,
                    Text = "A financial company requires that their Azure Blob Storage data be replicated synchronously across three availability zones within the same region to protect against datacenter failures while maintaining high performance. Which redundancy option should they choose?",
                    Options = new List<string>
                    {
                        "A) Locally Redundant Storage (LRS)",
                        "B) Zone-Redundant Storage (ZRS)",
                        "C) Geo-Redundant Storage (GRS)",
                        "D) Read-Access Geo-Redundant Storage (RA-GRS)"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Zone-Redundant Storage (ZRS)",
                    Difficulty = 3
                },

                // Q163 — Azure Files: SMB file share в облаке
                new Question
                {
                    Id = 163,
                    Text = "A company needs to provide a shared network drive accessible from both on-premises Windows servers and Azure Virtual Machines using the SMB protocol, without deploying and managing a Windows File Server. Which Azure storage service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure Blob Storage",
                        "B) Azure Queue Storage",
                        "C) Azure Table Storage",
                        "D) Azure Files"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Azure Files",
                    Difficulty = 1
                },

                // Q164 — Azure Table Storage: NoSQL key-value / wide-column
                new Question
                {
                    Id = 164,
                    Text = "A developer needs a low-cost, schema-less data store to persist millions of user preference records with simple key-value lookups. The data does not require complex querying, transactions, or referential integrity. Which Azure storage service is most cost-effective for this use case?",
                    Options = new List<string>
                    {
                        "A) Azure SQL Database",
                        "B) Azure Cosmos DB (Table API)",
                        "C) Azure Table Storage",
                        "D) Azure Blob Storage"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Table Storage",
                    Difficulty = 2
                },

                // Q165 — Lifecycle management policy: автоматический переход между тирами
                new Question
                {
                    Id = 165,
                    Text = "A company stores data in Azure Blob Storage and wants to automatically move blobs to the Cool tier after 30 days of inactivity and delete them after 365 days, without writing custom code or scripts. Which Azure Blob Storage feature enables this?",
                    Options = new List<string>
                    {
                        "A) Blob versioning",
                        "B) Azure Data Factory pipeline",
                        "C) Blob Storage lifecycle management policy",
                        "D) Azure Policy"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Blob Storage lifecycle management policy",
                    Difficulty = 2
                },

                // Q166 — Azure Private Endpoint / Private Link
                new Question
                {
                    Id = 166,
                    Text = "A company wants to access Azure SQL Database from their virtual machines using a private IP address within their VNet, ensuring that traffic does NOT traverse the public internet. Which Azure feature should they configure?",
                    Options = new List<string>
                    {
                        "A) VNet Service Endpoint",
                        "B) Azure Private Endpoint (Azure Private Link)",
                        "C) NSG with deny-internet rules",
                        "D) Azure Firewall FQDN filtering"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Private Endpoint (Azure Private Link)",
                    Difficulty = 3
                },

                // Q167 — Service Endpoint vs. Private Endpoint: разница
                new Question
                {
                    Id = 167,
                    Text = "What is the key difference between a VNet Service Endpoint and an Azure Private Endpoint when accessing Azure PaaS services like Azure Storage?",
                    Options = new List<string>
                    {
                        "A) Service Endpoint provides a private IP in the VNet; Private Endpoint uses a public IP.",
                        "B) Private Endpoint brings the service into the VNet with a private IP, eliminating public internet exposure entirely; Service Endpoint keeps the public endpoint but restricts access to the VNet.",
                        "C) There is no difference; both route traffic the same way.",
                        "D) Service Endpoint requires a VPN Gateway; Private Endpoint does not."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Private Endpoint brings the service into the VNet with a private IP, eliminating public internet exposure entirely; Service Endpoint keeps the public endpoint but restricts access to the VNet.",
                    Difficulty = 4
                },

                // Q168 — Azure Firewall vs. NSG: уровни защиты
                new Question
                {
                    Id = 168,
                    Text = "Which statement BEST describes the difference between Azure Firewall and Network Security Groups (NSGs)?",
                    Options = new List<string>
                    {
                        "A) NSGs and Azure Firewall provide identical functionality; use either one.",
                        "B) Azure Firewall is a fully managed, stateful firewall with advanced filtering (FQDN, threat intelligence, application rules) at the network perimeter; NSGs are stateless traffic filters applied at the subnet/NIC level.",
                        "C) NSGs can only be applied to virtual machines; Azure Firewall applies to all resources in a region.",
                        "D) Azure Firewall is free; NSGs incur per-rule charges."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Firewall is a fully managed, stateful firewall with advanced filtering (FQDN, threat intelligence, application rules) at the network perimeter; NSGs are stateless traffic filters applied at the subnet/NIC level.",
                    Difficulty = 4
                },

                // Q169 — Azure Front Door: global HTTP load balancer + WAF + CDN
                new Question
                {
                    Id = 169,
                    Text = "Which Azure networking service provides a global HTTP/HTTPS load balancer with SSL termination, web application firewall (WAF), URL-based routing, and built-in CDN capabilities to accelerate and protect web applications?",
                    Options = new List<string>
                    {
                        "A) Azure Traffic Manager",
                        "B) Azure Application Gateway",
                        "C) Azure Front Door",
                        "D) Azure Load Balancer"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Front Door",
                    Difficulty = 3
                },

                // Q170 — Azure DNS: хостинг DNS-записей в Azure
                new Question
                {
                    Id = 170,
                    Text = "A company manages DNS for their domain and wants to host their DNS zones in Azure for high availability, fast performance, and integration with their Azure resources. Which Azure service provides DNS zone hosting?",
                    Options = new List<string>
                    {
                        "A) Azure Traffic Manager",
                        "B) Azure DNS",
                        "C) Azure Application Gateway",
                        "D) Azure Private Link"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure DNS",
                    Difficulty = 1
                },

                // Q171 — GRS vs. RA-GRS: разница в read access
                new Question
                {
                    Id = 171,
                    Text = "What is the key difference between Geo-Redundant Storage (GRS) and Read-Access Geo-Redundant Storage (RA-GRS) for Azure Blob Storage?",
                    Options = new List<string>
                    {
                        "A) GRS replicates to two regions; RA-GRS replicates to three regions.",
                        "B) RA-GRS allows you to READ data from the secondary region at any time, even when the primary region is available; GRS only allows reads from the secondary during a failover.",
                        "C) GRS provides lower latency than RA-GRS.",
                        "D) RA-GRS is less expensive than GRS."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) RA-GRS allows you to READ data from the secondary region at any time, even when the primary region is available; GRS only allows reads from the secondary during a failover.",
                    Difficulty = 3
                },

                // Q172 — Shared Access Signature (SAS): ограниченный доступ к Blob
                new Question
                {
                    Id = 172,
                    Text = "A developer needs to provide a temporary, limited-permission URL that allows an external partner to upload a single file to Azure Blob Storage for the next 24 hours, without sharing the storage account key. Which mechanism should they use?",
                    Options = new List<string>
                    {
                        "A) Azure RBAC with the Storage Blob Data Contributor role",
                        "B) A Shared Access Signature (SAS) token",
                        "C) A Resource Lock",
                        "D) Azure AD Managed Identity"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) A Shared Access Signature (SAS) token",
                    Difficulty = 2
                },

                // Q173 — Azure Disk types: Ultra, Premium, Standard SSD, Standard HDD
                new Question
                {
                    Id = 173,
                    Text = "A database administrator needs to provision Azure Virtual Machine disks with the HIGHEST possible IOPS and sub-millisecond latency for a mission-critical OLTP database. Budget is not the primary concern. Which Azure disk type should they choose?",
                    Options = new List<string>
                    {
                        "A) Standard HDD Managed Disk",
                        "B) Standard SSD Managed Disk",
                        "C) Premium SSD Managed Disk",
                        "D) Ultra Disk"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Ultra Disk",
                    Difficulty = 3
                },

                // Q174 — Azure File Sync: гибридная синхронизация файлов
                new Question
                {
                    Id = 174,
                    Text = "A company has multiple remote offices each with a local file server. They want to centralize storage in Azure Files while still allowing fast local access to files from each office. Which Azure service enables hybrid file synchronization between on-premises file servers and Azure Files?",
                    Options = new List<string>
                    {
                        "A) Azure StorSimple",
                        "B) Azure Blob Storage with lifecycle management",
                        "C) Azure File Sync",
                        "D) Azure Data Box"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure File Sync",
                    Difficulty = 2
                },

                // Q175 — Azure Network Watcher: диагностика сети
                new Question
                {
                    Id = 175,
                    Text = "A network engineer needs to diagnose why traffic between two Azure Virtual Machines is being blocked, capture network packets for analysis, and verify effective NSG rules. Which Azure service provides these network diagnostics tools?",
                    Options = new List<string>
                    {
                        "A) Azure Monitor",
                        "B) Azure Network Watcher",
                        "C) Azure Traffic Analytics",
                        "D) Azure Security Center"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Network Watcher",
                    Difficulty = 2
                },

                // Q176 — Azure Virtual WAN: сетевой хаб для крупных предприятий
                new Question
                {
                    Id = 176,
                    Text = "A large enterprise needs to connect hundreds of branch offices and on-premises sites to Azure and to each other using a fully managed, hub-and-spoke networking architecture with optimized routing. Which Azure networking service is designed for this large-scale branch connectivity scenario?",
                    Options = new List<string>
                    {
                        "A) Azure ExpressRoute",
                        "B) Azure VPN Gateway with BGP",
                        "C) Azure Virtual WAN",
                        "D) Azure DNS Private Zones"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Virtual WAN",
                    Difficulty = 4
                },

                // Q177 — LRS: простейший тип избыточности
                new Question
                {
                    Id = 177,
                    Text = "Which Azure Storage redundancy option stores three copies of data synchronously within a SINGLE datacenter (a single availability zone) in the primary region, offering the lowest cost but no protection against datacenter-level failures?",
                    Options = new List<string>
                    {
                        "A) Zone-Redundant Storage (ZRS)",
                        "B) Geo-Redundant Storage (GRS)",
                        "C) Locally Redundant Storage (LRS)",
                        "D) Geo-Zone-Redundant Storage (GZRS)"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Locally Redundant Storage (LRS)",
                    Difficulty = 1
                },

                // Q178 — Hot vs. Archive: стоимость хранения vs. доступа
                new Question
                {
                    Id = 178,
                    Text = "When comparing Azure Blob Storage access tiers, which statement correctly describes the cost trade-off between the Hot tier and the Archive tier?",
                    Options = new List<string>
                    {
                        "A) Hot tier has lower storage cost but higher access/read cost than Archive.",
                        "B) Hot tier has higher storage cost per GB but lower access/read cost; Archive has very low storage cost but high retrieval cost and latency (rehydration).",
                        "C) Both tiers have the same storage cost, but Archive charges for early deletion.",
                        "D) Archive tier always has higher total costs than Hot tier."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Hot tier has higher storage cost per GB but lower access/read cost; Archive has very low storage cost but high retrieval cost and latency (rehydration).",
                    Difficulty = 3
                },

                // Q179 — Azure Load Balancer: Layer 4 (TCP/UDP)
                new Question
                {
                    Id = 179,
                    Text = "Which Azure load balancing service operates at OSI Layer 4 (TCP/UDP), distributes inbound traffic across backend Virtual Machines based on hash-based rules, and is suited for non-HTTP workloads such as a TCP-based database connection pool?",
                    Options = new List<string>
                    {
                        "A) Azure Application Gateway",
                        "B) Azure Front Door",
                        "C) Azure Traffic Manager",
                        "D) Azure Load Balancer (Standard)"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Azure Load Balancer (Standard)",
                    Difficulty = 3
                },

                // Q180 — Immutable Blob Storage: соответствие нормативным требованиям
                new Question
                {
                    Id = 180,
                    Text = "A financial company must store audit log data in a way that prevents ANY modification or deletion for a minimum of 7 years to comply with SEC regulations. Which Azure Blob Storage feature enforces this write-once, read-many (WORM) policy?",
                    Options = new List<string>
                    {
                        "A) Soft delete for blobs",
                        "B) Blob versioning",
                        "C) Immutable Blob Storage with time-based retention policy",
                        "D) Resource Locks on the storage account"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Immutable Blob Storage with time-based retention policy",
                    Difficulty = 4
                },

                // ==================== БЛОК 10 (181–200) — Управление затратами, ресурсы, инструменты ====================

                // Q181 — Cost Management budgets and alerts
                new Question
                {
                    Id = 181,
                    Text = "A company wants to receive an email notification when their Azure spending reaches 80% of their monthly budget, and automatically stop all virtual machines when it reaches 100%. Which Azure feature should they configure?",
                    Options = new List<string>
                    {
                        "A) Azure Advisor cost recommendations",
                        "B) Azure Cost Management budgets with alert actions",
                        "C) Azure Monitor metric alerts",
                        "D) Azure Policy with cost enforcement"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Cost Management budgets with alert actions",
                    Difficulty = 2
                },

                // Q182 — Azure Free Account: что включено
                new Question
                {
                    Id = 182,
                    Text = "Which of the following is TRUE about the Azure Free Account offer?",
                    Options = new List<string>
                    {
                        "A) It provides unlimited usage of all Azure services for 12 months.",
                        "B) It provides $200 credit for the first 30 days, free access to selected services for 12 months, and a set of always-free services.",
                        "C) It is available only for enterprise organizations with a minimum of 100 employees.",
                        "D) It does not require a credit card to sign up."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) It provides $200 credit for the first 30 days, free access to selected services for 12 months, and a set of always-free services.",
                    Difficulty = 2
                },

                // Q183 — Azure Marketplace: сторонние решения
                new Question
                {
                    Id = 183,
                    Text = "A company wants to deploy a third-party network virtual appliance (firewall product from a vendor like Palo Alto or Check Point) into their Azure environment directly from the Azure portal. Where would they find and deploy such an offering?",
                    Options = new List<string>
                    {
                        "A) Azure GitHub repository",
                        "B) Azure Marketplace",
                        "C) Azure Quickstart Templates gallery",
                        "D) Microsoft Download Center"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Marketplace",
                    Difficulty = 1
                },

                // Q184 — Azure Arc: управление ресурсами вне Azure
                new Question
                {
                    Id = 184,
                    Text = "A company runs servers on-premises and on AWS, and wants to manage them all using Azure security policies, Azure Monitor, and Azure Update Management from a single control plane. Which Azure service enables this unified management of non-Azure resources?",
                    Options = new List<string>
                    {
                        "A) Azure Migrate",
                        "B) Azure Arc",
                        "C) Azure Stack Hub",
                        "D) Azure ExpressRoute"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Arc",
                    Difficulty = 2
                },

                // Q185 — Log Analytics workspace: централизованный сбор логов
                new Question
                {
                    Id = 185,
                    Text = "Which Azure Monitor component serves as the central repository (data store) for collecting logs and metrics from Azure resources, on-premises servers, and other clouds, enabling unified querying using Kusto Query Language (KQL)?",
                    Options = new List<string>
                    {
                        "A) Azure Application Insights",
                        "B) Azure Monitor Metrics store",
                        "C) Log Analytics workspace",
                        "D) Azure Event Hubs"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Log Analytics workspace",
                    Difficulty = 2
                },

                // Q186 — Azure Service Health vs. Azure Status vs. Resource Health
                new Question
                {
                    Id = 186,
                    Text = "What is the difference between 'Azure Status', 'Azure Service Health', and 'Resource Health'?",
                    Options = new List<string>
                    {
                        "A) They are three names for the same dashboard.",
                        "B) Azure Status shows global Azure outages publicly; Service Health shows issues impacting YOUR subscriptions/regions; Resource Health shows the health of YOUR specific resources.",
                        "C) Azure Status is for IaaS only; Service Health is for PaaS; Resource Health is for SaaS.",
                        "D) Resource Health requires a paid support plan to access."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Status shows global Azure outages publicly; Service Health shows issues impacting YOUR subscriptions/regions; Resource Health shows the health of YOUR specific resources.",
                    Difficulty = 3
                },

                // Q187 — Azure Policy initiative (policy set)
                new Question
                {
                    Id = 187,
                    Text = "What is an Azure Policy *initiative* (also known as a policy set definition)?",
                    Options = new List<string>
                    {
                        "A) A single rule that denies or audits a specific resource configuration.",
                        "B) A collection of multiple policy definitions grouped together to achieve a broader compliance goal (e.g., all policies for ISO 27001 compliance).",
                        "C) A custom RBAC role with specific permissions.",
                        "D) A budget alert that enforces spending limits."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) A collection of multiple policy definitions grouped together to achieve a broader compliance goal (e.g., all policies for ISO 27001 compliance).",
                    Difficulty = 2
                },

                // Q188 — Azure Support Plans: уровни поддержки
                new Question
                {
                    Id = 188,
                    Text = "Which Azure Support Plan provides the fastest initial response time for critical business impact incidents (Sev A), a dedicated Technical Account Manager (TAM), and proactive guidance?",
                    Options = new List<string>
                    {
                        "A) Developer",
                        "B) Standard",
                        "C) Professional Direct",
                        "D) Unified (formerly Premier)"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Unified (formerly Premier)",
                    Difficulty = 3
                },

                // Q189 — Azure Resource Graph: query at scale
                new Question
                {
                    Id = 189,
                    Text = "An administrator needs to write a single query that returns a list of all virtual machines across all subscriptions in a Management Group that do not have a specific tag applied. Which Azure service enables querying resources at this scale efficiently?",
                    Options = new List<string>
                    {
                        "A) Azure Monitor Log Analytics",
                        "B) Azure Resource Graph",
                        "C) Azure Cost Management",
                        "D) Azure Policy compliance report"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Resource Graph",
                    Difficulty = 4
                },

                // Q190 — Azure Bicep: IaC альтернатива ARM JSON
                new Question
                {
                    Id = 190,
                    Text = "Which Azure infrastructure-as-code language provides a simpler, more readable syntax than ARM JSON templates, compiles down to ARM JSON, and is the recommended approach for new Azure deployments by Microsoft?",
                    Options = new List<string>
                    {
                        "A) Terraform",
                        "B) Azure Bicep",
                        "C) Azure CLI scripts",
                        "D) Azure PowerShell DSC"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Bicep",
                    Difficulty = 2
                },

                // Q191 — Azure Subscription types: EA, MCA, CSP, PAYG
                new Question
                {
                    Id = 191,
                    Text = "A large enterprise with 5,000 employees wants to purchase Azure services in bulk with volume discounts, a committed annual spend, and centralized billing across all their business units. Which Azure purchasing model best fits this scenario?",
                    Options = new List<string>
                    {
                        "A) Pay-As-You-Go (PAYG)",
                        "B) Azure Free Account",
                        "C) Enterprise Agreement (EA)",
                        "D) Cloud Solution Provider (CSP)"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Enterprise Agreement (EA)",
                    Difficulty = 2
                },

                // Q192 — Action Groups: уведомления и автоматические действия
                new Question
                {
                    Id = 192,
                    Text = "In Azure Monitor, which feature allows you to define a set of notification targets (email, SMS, webhook, ITSM) and automation actions (Azure Function, Runbook) that are triggered together when an alert fires?",
                    Options = new List<string>
                    {
                        "A) Alert rules",
                        "B) Diagnostic settings",
                        "C) Action Groups",
                        "D) Log Analytics workspace"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Action Groups",
                    Difficulty = 2
                },

                // Q193 — Azure Portal Mobile App
                new Question
                {
                    Id = 193,
                    Text = "Which tool allows Azure administrators to monitor resources, receive alerts, run shell commands (Cloud Shell), and restart virtual machines from their iOS or Android smartphone?",
                    Options = new List<string>
                    {
                        "A) Azure CLI installed on mobile",
                        "B) Azure Mobile App",
                        "C) Azure Monitor mobile dashboard",
                        "D) Azure DevOps mobile app"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Mobile App",
                    Difficulty = 1
                },

                // Q194 — Preview features: GA vs. Preview
                new Question
                {
                    Id = 194,
                    Text = "What does it mean when an Azure service is in 'Public Preview' status?",
                    Options = new List<string>
                    {
                        "A) The service is fully supported with an SLA and recommended for production workloads.",
                        "B) The service is available to all customers for evaluation and feedback, but may have limited SLAs and is not recommended for production workloads.",
                        "C) The service is available only to Microsoft internal teams.",
                        "D) The service has been deprecated and will be removed soon."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) The service is available to all customers for evaluation and feedback, but may have limited SLAs and is not recommended for production workloads.",
                    Difficulty = 1
                },

                // Q195 — TCO Calculator: правильный сценарий использования
                new Question
                {
                    Id = 195,
                    Text = "The CFO of a company considering cloud migration asks: 'How much money can we save by moving our 200 on-premises servers to Azure over the next 5 years?' Which Azure tool is specifically designed to answer this question?",
                    Options = new List<string>
                    {
                        "A) Azure Pricing Calculator",
                        "B) Azure Cost Management + Billing",
                        "C) Azure Advisor",
                        "D) Total Cost of Ownership (TCO) Calculator"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Total Cost of Ownership (TCO) Calculator",
                    Difficulty = 1
                },

                // Q196 — Azure Stack Hub: Azure в частном ЦОД
                new Question
                {
                    Id = 196,
                    Text = "A government agency must process sensitive data in a disconnected environment (no public internet access) but wants to use Azure services and APIs on-premises in their own datacenter to comply with data sovereignty laws. Which Microsoft offering enables this?",
                    Options = new List<string>
                    {
                        "A) Azure Arc",
                        "B) Azure Private Link",
                        "C) Azure Stack Hub",
                        "D) Azure Government Cloud"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Stack Hub",
                    Difficulty = 3
                },

                // Q197 — Consumption-based pricing: главное преимущество
                new Question
                {
                    Id = 197,
                    Text = "Which statement BEST describes the consumption-based (pay-as-you-go) pricing model of cloud computing compared to traditional on-premises CapEx?",
                    Options = new List<string>
                    {
                        "A) You pay a fixed monthly fee regardless of how much you use.",
                        "B) You pay only for the resources you use, when you use them, without upfront commitment.",
                        "C) You purchase a minimum capacity commitment in advance for a discount.",
                        "D) You pay once and own the infrastructure permanently."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) You pay only for the resources you use, when you use them, without upfront commitment.",
                    Difficulty = 1
                },

                // Q198 — Azure Reservations: 1- or 3-year commitment
                new Question
                {
                    Id = 198,
                    Text = "A company runs a set of Azure Virtual Machines continuously 24/7 and expects to do so for the next 3 years. Which pricing option will provide the GREATEST discount compared to pay-as-you-go pricing?",
                    Options = new List<string>
                    {
                        "A) Azure Spot Virtual Machines",
                        "B) Azure Hybrid Benefit",
                        "C) 3-year Azure Reserved VM Instances",
                        "D) Azure Dev/Test Pricing"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) 3-year Azure Reserved VM Instances",
                    Difficulty = 2
                },

                // Q199 — Иерархия управления Azure (сводный)
                new Question
                {
                    Id = 199,
                    Text = "Which is the CORRECT hierarchical order of Azure management scopes, from the broadest to the most granular?",
                    Options = new List<string>
                    {
                        "A) Subscriptions → Management Groups → Resource Groups → Resources",
                        "B) Management Groups → Subscriptions → Resource Groups → Resources",
                        "C) Tenants → Resource Groups → Subscriptions → Resources",
                        "D) Management Groups → Resource Groups → Subscriptions → Resources"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Management Groups → Subscriptions → Resource Groups → Resources",
                    Difficulty = 2
                },

                // Q200 — Azure Policy Remediation: автоматическое исправление
                new Question
                {
                    Id = 200,
                    Text = "An Azure Policy is configured with the 'DeployIfNotExists' effect to automatically deploy a Log Analytics agent on all virtual machines that do not have one installed. When a new VM is created WITHOUT the agent, what does the policy do?",
                    Options = new List<string>
                    {
                        "A) It blocks the creation of the VM.",
                        "B) It marks the VM as non-compliant and sends an alert, but takes no automatic action.",
                        "C) It automatically deploys the Log Analytics agent to the VM as a remediation action.",
                        "D) It tags the VM as 'non-compliant' and requires manual review within 30 days."
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) It automatically deploys the Log Analytics agent to the VM as a remediation action.",
                    Difficulty = 3
                },

                // ==================== БЛОК 11 (201–220) — DR, резервное копирование, миграция ====================

                // Q201 — Azure Site Recovery: DR для VM
                new Question
                {
                    Id = 201,
                    Text = "A company needs to replicate Azure Virtual Machines running in East US to West US so that if the East US region fails, the VMs can be quickly failed over and started in West US. Which Azure service provides this disaster recovery orchestration?",
                    Options = new List<string>
                    {
                        "A) Azure Backup",
                        "B) Azure Site Recovery (ASR)",
                        "C) Geo-redundant storage (GRS)",
                        "D) Azure Traffic Manager"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Site Recovery (ASR)",
                    Difficulty = 2
                },

                // Q202 — Azure Backup: управляемое резервное копирование
                new Question
                {
                    Id = 202,
                    Text = "Which Azure service provides a centralized, cloud-based backup solution for Azure VMs, on-premises servers (via MARS agent), Azure SQL databases, and Azure Files, with long-term retention and restore capabilities?",
                    Options = new List<string>
                    {
                        "A) Azure Site Recovery",
                        "B) Azure Blob Storage with GRS",
                        "C) Azure Backup",
                        "D) Azure Archive Storage"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Backup",
                    Difficulty = 1
                },

                // Q203 — RTO vs RPO: определения
                new Question
                {
                    Id = 203,
                    Text = "A company's disaster recovery plan states: 'We must restore the system within 4 hours of a failure, and we can tolerate losing up to 1 hour of data.' Which metrics do '4 hours' and '1 hour' represent, respectively?",
                    Options = new List<string>
                    {
                        "A) RPO = 4 hours; RTO = 1 hour",
                        "B) RTO = 4 hours; RPO = 1 hour",
                        "C) SLA = 4 hours; MTR = 1 hour",
                        "D) MTD = 4 hours; MTTR = 1 hour"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) RTO = 4 hours; RPO = 1 hour",
                    Difficulty = 2
                },

                // Q204 — Azure Migrate: discovery and assessment
                new Question
                {
                    Id = 204,
                    Text = "A company is planning to migrate its on-premises VMware workloads to Azure. Before migrating, they need to discover all VMs, assess their readiness for Azure, estimate right-sized Azure VM SKUs, and calculate migration costs. Which Azure service provides this pre-migration discovery and assessment capability?",
                    Options = new List<string>
                    {
                        "A) Azure Site Recovery",
                        "B) Azure Migrate",
                        "C) Azure Data Box",
                        "D) Azure Arc"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Migrate",
                    Difficulty = 2
                },

                // Q205 — Azure Database Migration Service (DMS)
                new Question
                {
                    Id = 205,
                    Text = "A company needs to migrate their on-premises Oracle database to Azure SQL Database with minimal downtime using continuous data sync. Which Azure service is specifically designed for database schema conversion and live database migration?",
                    Options = new List<string>
                    {
                        "A) Azure Data Factory",
                        "B) Azure Database Migration Service (DMS)",
                        "C) Azure Backup",
                        "D) Azure Import/Export"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Database Migration Service (DMS)",
                    Difficulty = 3
                },

                // Q206 — Azure Paired Regions: концепция
                new Question
                {
                    Id = 206,
                    Text = "What is the primary benefit of Azure Paired Regions?",
                    Options = new List<string>
                    {
                        "A) Paired regions always have lower latency between them than non-paired regions.",
                        "B) Microsoft staggers planned maintenance updates so that both paired regions are not updated simultaneously, and if a broad failure occurs, at least one region in each pair is prioritized for recovery.",
                        "C) Resources in paired regions automatically share the same network and billing.",
                        "D) Data stored in one paired region is automatically replicated to the other for free."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Microsoft staggers planned maintenance updates so that both paired regions are not updated simultaneously, and if a broad failure occurs, at least one region in each pair is prioritized for recovery.",
                    Difficulty = 3
                },

                // Q207 — Recovery Services Vault: контейнер для backup и ASR
                new Question
                {
                    Id = 207,
                    Text = "Which Azure construct serves as the management container and storage location for both Azure Backup and Azure Site Recovery data, holding backup policies, protected items, and recovery points?",
                    Options = new List<string>
                    {
                        "A) Azure Storage Account",
                        "B) Resource Group",
                        "C) Recovery Services Vault",
                        "D) Azure Key Vault"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Recovery Services Vault",
                    Difficulty = 2
                },

                // Q208 — HA vs. DR: принципиальная разница
                new Question
                {
                    Id = 208,
                    Text = "What is the PRIMARY conceptual difference between High Availability (HA) and Disaster Recovery (DR)?",
                    Options = new List<string>
                    {
                        "A) HA and DR are the same thing — both protect against outages.",
                        "B) HA focuses on minimizing downtime from expected failures through redundancy within the same infrastructure; DR focuses on recovering from catastrophic, large-scale outages by switching to a separate infrastructure.",
                        "C) HA is only applicable to databases; DR applies to all workloads.",
                        "D) DR provides better performance than HA."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) HA focuses on minimizing downtime from expected failures through redundancy within the same infrastructure; DR focuses on recovering from catastrophic, large-scale outages by switching to a separate infrastructure.",
                    Difficulty = 2
                },

                // Q209 — Composite SLA: расчёт
                new Question
                {
                    Id = 209,
                    Text = "An application uses two Azure services in sequence: Service A with SLA = 99.9% and Service B with SLA = 99.95%. What is the composite SLA of the application?",
                    Options = new List<string>
                    {
                        "A) 99.95% (the higher of the two SLAs)",
                        "B) 99.9% (the lower of the two SLAs)",
                        "C) Approximately 99.85% (99.9% × 99.95%)",
                        "D) 100% because Azure guarantees full availability"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Approximately 99.85% (99.9% × 99.95%)",
                    Difficulty = 3
                },

                // Q210 — Data Box Heavy: offline transfer >500 TB
                new Question
                {
                    Id = 210,
                    Text = "A media company needs to transfer approximately 800 TB of video content to Azure Blob Storage. Their internet connection speed would result in a transfer time of over 6 months online. Which Azure service should they use to transfer this data offline?",
                    Options = new List<string>
                    {
                        "A) Azure ExpressRoute",
                        "B) Azure Data Factory with self-hosted integration runtime",
                        "C) Azure Data Box Heavy",
                        "D) AzCopy with parallel transfer optimization"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Data Box Heavy",
                    Difficulty = 2
                },

                // Q211 — SLA для single VM с Premium SSD
                new Question
                {
                    Id = 211,
                    Text = "What is the published Azure SLA for a single Virtual Machine that uses Premium SSD managed disks for all of its disk storage?",
                    Options = new List<string>
                    {
                        "A) 99.0%",
                        "B) 99.5%",
                        "C) 99.9%",
                        "D) 99.99%"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) 99.9%",
                    Difficulty = 2
                },

                // Q212 — Fault Domain vs. Update Domain в Availability Set
                new Question
                {
                    Id = 212,
                    Text = "When deploying Virtual Machines in an Azure Availability Set, what do *Fault Domains* and *Update Domains* protect against, respectively?",
                    Options = new List<string>
                    {
                        "A) Fault Domains protect against planned maintenance; Update Domains protect against hardware failures.",
                        "B) Fault Domains protect against hardware failures (shared power/networking); Update Domains protect against planned Azure maintenance reboots.",
                        "C) Both Fault Domains and Update Domains protect against hardware failures only.",
                        "D) Update Domains protect against hardware failures; Fault Domains protect against planned maintenance."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Fault Domains protect against hardware failures (shared power/networking); Update Domains protect against planned Azure maintenance reboots.",
                    Difficulty = 3
                },

                // Q213 — ASR: on-prem to Azure DR
                new Question
                {
                    Id = 213,
                    Text = "A company wants to use Azure as a disaster recovery target for their on-premises Hyper-V virtual machines. In the event of an on-premises outage, the VMs should automatically fail over to Azure and be accessible within minutes. Which Azure service provides this capability?",
                    Options = new List<string>
                    {
                        "A) Azure Migrate",
                        "B) Azure Backup with instant restore",
                        "C) Azure Site Recovery (ASR)",
                        "D) Azure Arc"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Site Recovery (ASR)",
                    Difficulty = 2
                },

                // Q214 — Cloud bursting: hybrid pattern
                new Question
                {
                    Id = 214,
                    Text = "A company runs most of its workloads on-premises but during peak periods (e.g., month-end financial processing), they need additional compute capacity. They want to automatically expand into Azure only when needed and revert to on-premises when demand decreases. This pattern is called:",
                    Options = new List<string>
                    {
                        "A) Cloud migration",
                        "B) Cloud bursting",
                        "C) Hybrid identity",
                        "D) Geo-distribution"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Cloud bursting",
                    Difficulty = 2
                },

                // Q215 — GZRS: максимальная избыточность
                new Question
                {
                    Id = 215,
                    Text = "Which Azure Storage redundancy option provides the HIGHEST level of durability by replicating data across availability zones in the primary region AND asynchronously to a secondary geographic region?",
                    Options = new List<string>
                    {
                        "A) Zone-Redundant Storage (ZRS)",
                        "B) Geo-Redundant Storage (GRS)",
                        "C) Locally Redundant Storage (LRS)",
                        "D) Geo-Zone-Redundant Storage (GZRS)"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) Geo-Zone-Redundant Storage (GZRS)",
                    Difficulty = 3
                },

                // Q216 — SLA = 0% без HA конфигурации (single VM, standard HDD)
                new Question
                {
                    Id = 216,
                    Text = "Which Azure Virtual Machine configuration does Microsoft NOT publish a formal SLA for (i.e., does NOT guarantee an uptime SLA for the VM's availability)?",
                    Options = new List<string>
                    {
                        "A) A single VM using Premium SSD managed disks",
                        "B) Two or more VMs deployed in an Availability Set",
                        "C) A single VM using only Standard HDD managed disks",
                        "D) Two or more VMs deployed across Availability Zones"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) A single VM using only Standard HDD managed disks",
                    Difficulty = 3
                },

                // Q217 — Azure Backup soft delete
                new Question
                {
                    Id = 217,
                    Text = "Which Azure Backup feature retains deleted backup data for 14 additional days at no charge, protecting against accidental or malicious deletion of backup items, and allows recovery within that period?",
                    Options = new List<string>
                    {
                        "A) Backup immutability policy",
                        "B) Geo-redundant backup vault",
                        "C) Soft delete for Azure Backup",
                        "D) Azure Backup long-term retention"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Soft delete for Azure Backup",
                    Difficulty = 2
                },

                // Q218 — Azure Migrate: lift and shift
                new Question
                {
                    Id = 218,
                    Text = "Which cloud migration strategy (also called 'Rehost') involves moving an existing on-premises application to the cloud with minimal or no code changes, essentially deploying the same application on cloud VMs?",
                    Options = new List<string>
                    {
                        "A) Refactor (Re-architect)",
                        "B) Replace (SaaS adoption)",
                        "C) Lift-and-Shift (Rehost)",
                        "D) Retire (Decommission)"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Lift-and-Shift (Rehost)",
                    Difficulty = 1
                },

                // Q219 — Availability Zones SLA: 99.99%
                new Question
                {
                    Id = 219,
                    Text = "When two or more Azure Virtual Machines are deployed across two or more Availability Zones in the same region, what is the Microsoft-published SLA for VM connectivity?",
                    Options = new List<string>
                    {
                        "A) 99.0%",
                        "B) 99.9%",
                        "C) 99.95%",
                        "D) 99.99%"
                    },
                    CorrectAnswer = "D",
                    CorrectAnswerText = "D) 99.99%",
                    Difficulty = 2
                },

                // Q220 — Azure Dedicated Host: физическая изоляция
                new Question
                {
                    Id = 220,
                    Text = "A company must comply with regulatory requirements that mandate their virtual machines run on physical servers NOT shared with any other customer's workloads. Which Azure offering provides this dedicated physical server isolation?",
                    Options = new List<string>
                    {
                        "A) Azure Isolated VM sizes (e.g., Standard_E80ids_v4)",
                        "B) Azure Confidential Computing",
                        "C) Azure Dedicated Host",
                        "D) Azure Reserved Instances"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Dedicated Host",
                    Difficulty = 3
                },

                // ==================== БЛОК 12 (221–240) — Сложные экзаменационные сценарии ====================

                // Q221 — SaaS примеры: Office 365, Dynamics 365
                new Question
                {
                    Id = 221,
                    Text = "Which of the following are examples of Software as a Service (SaaS)? (Choose the BEST answer)",
                    Options = new List<string>
                    {
                        "A) Microsoft Azure Virtual Machines and Azure Kubernetes Service",
                        "B) Microsoft 365 (Office 365) and Dynamics 365",
                        "C) Azure App Service and Azure SQL Database",
                        "D) Azure Active Directory and Azure Policy"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Microsoft 365 (Office 365) and Dynamics 365",
                    Difficulty = 1
                },

                // Q222 — IaaS, PaaS, SaaS: распределение ответственности (сводный)
                new Question
                {
                    Id = 222,
                    Text = "Which of the following correctly maps the cloud service model to a typical Azure service?",
                    Options = new List<string>
                    {
                        "A) IaaS = Azure SQL Database; PaaS = Azure Virtual Machines; SaaS = Microsoft 365",
                        "B) IaaS = Azure Virtual Machines; PaaS = Azure App Service; SaaS = Microsoft 365",
                        "C) IaaS = Azure Functions; PaaS = Azure Virtual Machines; SaaS = Azure Blob Storage",
                        "D) IaaS = Azure Kubernetes Service; PaaS = Azure Virtual Machines; SaaS = Azure Cosmos DB"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) IaaS = Azure Virtual Machines; PaaS = Azure App Service; SaaS = Microsoft 365",
                    Difficulty = 1
                },

                // Q223 — Fault Tolerance vs. High Availability: разница
                new Question
                {
                    Id = 223,
                    Text = "What is the difference between *fault tolerance* and *high availability* in cloud computing?",
                    Options = new List<string>
                    {
                        "A) They are synonymous; both describe systems that never fail.",
                        "B) Fault tolerance means the system continues to operate with ZERO disruption even when a component fails; high availability minimizes downtime but may have brief interruptions during failover.",
                        "C) High availability is a software feature; fault tolerance is a hardware feature.",
                        "D) Fault tolerance applies only to databases; high availability applies only to compute."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Fault tolerance means the system continues to operate with ZERO disruption even when a component fails; high availability minimizes downtime but may have brief interruptions during failover.",
                    Difficulty = 3
                },

                // Q224 — Azure Static Web Apps: статические веб-приложения
                new Question
                {
                    Id = 224,
                    Text = "A developer is building a React single-page application (SPA) with an API backend using Azure Functions. They want a hosting service that automatically builds and deploys from GitHub, handles global CDN distribution of the static files, and integrates the Functions API — with a free tier. Which Azure service is the best fit?",
                    Options = new List<string>
                    {
                        "A) Azure App Service",
                        "B) Azure Container Instances",
                        "C) Azure Static Web Apps",
                        "D) Azure Blob Storage with static website hosting"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Static Web Apps",
                    Difficulty = 3
                },

                // Q225 — Multi-cloud: определение
                new Question
                {
                    Id = 225,
                    Text = "A company uses Azure for its primary workloads, AWS for its data analytics platform, and Google Cloud for its AI/ML pipeline. This architecture is BEST described as:",
                    Options = new List<string>
                    {
                        "A) Hybrid cloud",
                        "B) Private cloud",
                        "C) Multi-cloud",
                        "D) Community cloud"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Multi-cloud",
                    Difficulty = 1
                },

                // Q226 — Azure Functions vs. Logic Apps: ключевые отличия
                new Question
                {
                    Id = 226,
                    Text = "Which statement BEST describes the primary difference between Azure Functions and Azure Logic Apps?",
                    Options = new List<string>
                    {
                        "A) Azure Functions only supports C#; Logic Apps supports all languages.",
                        "B) Azure Functions is a code-first serverless compute service for custom logic; Azure Logic Apps is a low-code workflow orchestration service with 400+ pre-built connectors.",
                        "C) Logic Apps can run for unlimited duration; Functions have a maximum of 5 minutes.",
                        "D) Azure Functions can only be triggered by HTTP; Logic Apps supports all trigger types."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Functions is a code-first serverless compute service for custom logic; Azure Logic Apps is a low-code workflow orchestration service with 400+ pre-built connectors.",
                    Difficulty = 2
                },

                // Q227 — Azure Container Apps: serverless container platform
                new Question
                {
                    Id = 227,
                    Text = "A team wants to deploy microservices as containers that scale to zero when idle (to save costs) and scale up automatically based on HTTP traffic or queue length, without managing Kubernetes or virtual machines. Which Azure service is designed for this scenario?",
                    Options = new List<string>
                    {
                        "A) Azure Kubernetes Service (AKS)",
                        "B) Azure Container Instances (ACI)",
                        "C) Azure Container Apps",
                        "D) Azure App Service for Containers"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Container Apps",
                    Difficulty = 3
                },

                // Q228 — Общедоступность Azure (глобальная инфраструктура)
                new Question
                {
                    Id = 228,
                    Text = "Which statement accurately describes a key aspect of Azure's global infrastructure?",
                    Options = new List<string>
                    {
                        "A) Azure has datacenters in only 5 geographic regions worldwide.",
                        "B) Each Azure region consists of a single datacenter to maximize resource density.",
                        "C) Azure consists of 60+ regions worldwide, many consisting of multiple physical datacenters connected by a high-speed private fiber network.",
                        "D) All Azure regions are located in the United States to comply with US data protection laws."
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure consists of 60+ regions worldwide, many consisting of multiple physical datacenters connected by a high-speed private fiber network.",
                    Difficulty = 1
                },

                // Q229 — Azure Confidential Computing: защита данных в процессе обработки
                new Question
                {
                    Id = 229,
                    Text = "A healthcare company is processing highly sensitive patient data in Azure and requires that the data be protected not only at rest and in transit, but also while it is being actively processed in memory (in use), to prevent even privileged cloud operators from accessing it. Which Azure capability addresses this requirement?",
                    Options = new List<string>
                    {
                        "A) Azure Key Vault with customer-managed keys",
                        "B) Azure Dedicated Host",
                        "C) Azure Confidential Computing (Trusted Execution Environments)",
                        "D) Azure Policy with encryption enforcement"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Confidential Computing (Trusted Execution Environments)",
                    Difficulty = 4
                },

                // Q230 — Agility vs. Scalability: разница
                new Question
                {
                    Id = 230,
                    Text = "Which cloud benefit allows a company to deploy new development environments in minutes, experiment quickly with new ideas, and decommission resources immediately after use — as opposed to waiting weeks for hardware procurement?",
                    Options = new List<string>
                    {
                        "A) Elasticity",
                        "B) Fault Tolerance",
                        "C) Agility",
                        "D) Scalability"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Agility",
                    Difficulty = 2
                },

                // Q231 — SLA composite: последовательные vs. параллельные сервисы
                new Question
                {
                    Id = 231,
                    Text = "An application depends on two Azure services deployed in PARALLEL (either one can serve requests independently): Service X with SLA = 99% and Service Y with SLA = 99%. What is the composite availability?",
                    Options = new List<string>
                    {
                        "A) 99% × 99% = 98.01%",
                        "B) 100% − (1% × 1%) = 99.99%",
                        "C) (99% + 99%) / 2 = 99%",
                        "D) The SLA is undefined for parallel services."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) 100% − (1% × 1%) = 99.99%",
                    Difficulty = 5
                },

                // Q232 — Azure Sovereign / Government Cloud
                new Question
                {
                    Id = 232,
                    Text = "Which Azure offering is a physically separate instance of Azure designed to meet the strict compliance and data residency requirements of US government agencies, with access limited to screened US citizens?",
                    Options = new List<string>
                    {
                        "A) Azure Stack Hub",
                        "B) Azure Government Cloud",
                        "C) Azure China (operated by 21Vianet)",
                        "D) Azure Private Cloud"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Government Cloud",
                    Difficulty = 2
                },

                // Q233 — Predictability in cloud (cost + performance)
                new Question
                {
                    Id = 233,
                    Text = "Which cloud benefit refers to the ability to forecast future costs and resource performance with confidence, enabling organizations to plan budgets and maintain consistent application behavior?",
                    Options = new List<string>
                    {
                        "A) Reliability",
                        "B) Scalability",
                        "C) Predictability",
                        "D) Manageability"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Predictability",
                    Difficulty = 2
                },

                // Q234 — Manageability in cloud: инструменты управления
                new Question
                {
                    Id = 234,
                    Text = "Which of the following BEST illustrates the cloud benefit of *manageability*?",
                    Options = new List<string>
                    {
                        "A) Being able to automatically scale resources when CPU usage exceeds 80%.",
                        "B) Being able to deploy resources using templates, monitor health, and receive alerts — from the portal, CLI, API, or PowerShell — without physical access to hardware.",
                        "C) Maintaining 99.99% availability through redundant infrastructure.",
                        "D) Encrypting all data at rest and in transit automatically."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Being able to deploy resources using templates, monitor health, and receive alerts — from the portal, CLI, API, or PowerShell — without physical access to hardware.",
                    Difficulty = 2
                },

                // Q235 — Vertical vs. Horizontal scaling: разница
                new Question
                {
                    Id = 235,
                    Text = "What is the difference between *vertical scaling* (scaling up/down) and *horizontal scaling* (scaling out/in)?",
                    Options = new List<string>
                    {
                        "A) Vertical scaling adds more instances; horizontal scaling increases the size of existing instances.",
                        "B) Vertical scaling increases the capacity of an existing resource (e.g., more CPU/RAM); horizontal scaling adds more instances of the same resource.",
                        "C) Vertical scaling is used for stateless applications; horizontal scaling is for stateful applications.",
                        "D) There is no meaningful difference — both achieve the same result."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Vertical scaling increases the capacity of an existing resource (e.g., more CPU/RAM); horizontal scaling adds more instances of the same resource.",
                    Difficulty = 1
                },

                // Q236 — Azure Spring Apps: Java microservices PaaS
                new Question
                {
                    Id = 236,
                    Text = "A Java development team using the Spring Boot and Spring Cloud framework wants a fully managed PaaS environment that handles service discovery, config management, and scaling for their microservices without managing infrastructure. Which Azure service is purpose-built for this?",
                    Options = new List<string>
                    {
                        "A) Azure App Service",
                        "B) Azure Kubernetes Service (AKS)",
                        "C) Azure Spring Apps",
                        "D) Azure Container Instances"
                    },
                    CorrectAnswer = "C",
                    CorrectAnswerText = "C) Azure Spring Apps",
                    Difficulty = 4
                },

                // Q237 — Azure применяет шифрование by default (encryption at rest)
                new Question
                {
                    Id = 237,
                    Text = "Which statement is TRUE about data encryption at rest in Azure?",
                    Options = new List<string>
                    {
                        "A) Customers must manually enable encryption for each storage service; it is not on by default.",
                        "B) Azure encrypts all customer data at rest by default using platform-managed keys, with the option to use customer-managed keys in Azure Key Vault.",
                        "C) Encryption at rest is only available for Premium storage tiers.",
                        "D) Only Azure SQL Database supports encryption at rest; other services require third-party tools."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure encrypts all customer data at rest by default using platform-managed keys, with the option to use customer-managed keys in Azure Key Vault.",
                    Difficulty = 2
                },

                // Q238 — Azure применяет шифрование in transit (TLS)
                new Question
                {
                    Id = 238,
                    Text = "Which statement is TRUE about data encryption in transit in Azure?",
                    Options = new List<string>
                    {
                        "A) Azure does not encrypt data in transit; customers must implement their own TLS.",
                        "B) Data transferred between Azure datacenters and between users and Azure services is protected using industry-standard protocols such as TLS, and Azure enforces HTTPS for most services.",
                        "C) Encryption in transit is only available with Azure ExpressRoute connections.",
                        "D) Azure encrypts data in transit only for SaaS services; IaaS and PaaS require manual configuration."
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Data transferred between Azure datacenters and between users and Azure services is protected using industry-standard protocols such as TLS, and Azure enforces HTTPS for most services.",
                    Difficulty = 2
                },

                // Q239 — Azure Well-Architected Framework: 5 pillars
                new Question
                {
                    Id = 239,
                    Text = "The Azure Well-Architected Framework defines five pillars for building high-quality cloud solutions. Which answer correctly lists ALL five pillars?",
                    Options = new List<string>
                    {
                        "A) Cost Optimization, Operational Excellence, Performance Efficiency, Reliability, Security",
                        "B) Cost Management, DevOps, Scalability, Compliance, Security",
                        "C) High Availability, Disaster Recovery, Security, Cost, Performance",
                        "D) Reliability, Security, Efficiency, Compliance, Innovation"
                    },
                    CorrectAnswer = "A",
                    CorrectAnswerText = "A) Cost Optimization, Operational Excellence, Performance Efficiency, Reliability, Security",
                    Difficulty = 3
                },

                // Q240 — Финальный многоаспектный сценарий
                new Question
                {
                    Id = 240,
                    Text = "A global e-commerce company requires: (1) global routing to the nearest healthy backend, (2) WAF to block SQL injection, (3) SSL termination at the edge, and (4) CDN caching for static assets — all in a single managed Azure service. Which service should they use?",
                    Options = new List<string>
                    {
                        "A) Azure Traffic Manager + Azure Application Gateway + Azure CDN (three separate services)",
                        "B) Azure Front Door (with integrated WAF and CDN capabilities)",
                        "C) Azure Load Balancer + Azure Firewall",
                        "D) Azure API Management + Azure DDoS Protection Standard"
                    },
                    CorrectAnswer = "B",
                    CorrectAnswerText = "B) Azure Front Door (with integrated WAF and CDN capabilities)",
                    Difficulty = 4
                }
            };
        }
    }
}
