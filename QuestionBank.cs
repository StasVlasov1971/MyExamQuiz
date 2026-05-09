using System.Collections.Generic;
using System.Linq;

namespace AzureExamQuestions
{
    public static class QuestionBank
    {
        public static List<Question> GetAllQuestions()
        {
            return new List<Question>
            {
                // ==================== БЛОК 1 (Вопросы 1-20) — Базовые облачные концепции ====================
                new Question
                {
                    Id = 1,
                    Text = "Which of the following cloud deployment models provides computing resources exclusively for a single organization, and can be hosted either on-premises or by a third-party provider?",
                    Options = new List<string> { "A) Public cloud", "B) Hybrid cloud", "C) Community cloud", "D) Private cloud" },
                    CorrectAnswer = "D", CorrectAnswerText = "D) Private cloud", Difficulty = 1
                },
                new Question
                {
                    Id = 2,
                    Text = "What is the primary advantage of the CapEx (Capital Expenditure) model in an on-premises datacenter?",
                    Options = new List<string> { "A) It shifts costs from upfront investment to operational spending.", "B) It requires no physical hardware maintenance.", "C) It allows for predictable budgeting through asset depreciation.", "D) It automatically scales resources based on demand." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) It allows for predictable budgeting through asset depreciation.", Difficulty = 2
                },
                new Question
                {
                    Id = 3,
                    Text = "Your company wants to deploy a web application without managing any underlying operating systems, servers, or storage. Which cloud service model should you use?",
                    Options = new List<string> { "A) Infrastructure as a Service (IaaS)", "B) Platform as a Service (PaaS)", "C) Software as a Service (SaaS)", "D) Function as a Service (FaaS)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Platform as a Service (PaaS)", Difficulty = 1
                },
                new Question
                {
                    Id = 4,
                    Text = "Which cloud benefit is described as the ability to increase or decrease resources *automatically* in response to changing workload demands?",
                    Options = new List<string> { "A) Scalability", "B) Elasticity", "C) Agility", "D) Fault Tolerance" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Elasticity", Difficulty = 2
                },
                new Question
                {
                    Id = 5,
                    Text = "A company runs its critical legacy application in its own datacenter but uses Azure Active Directory for identity management and Azure Blob Storage for archival data. This is an example of which cloud deployment model?",
                    Options = new List<string> { "A) Public cloud only", "B) Private cloud only", "C) Hybrid cloud", "D) Multi-cloud" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Hybrid cloud", Difficulty = 2
                },
                new Question
                {
                    Id = 6,
                    Text = "Which of the following is a *characteristic* of public cloud computing, but NOT typically of a private cloud?",
                    Options = new List<string> { "A) High level of security and control", "B) Consumption-based pricing (pay-as-you-go)", "C) Dedicated hardware for a single tenant", "D) Requires in-house IT expertise for maintenance" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Consumption-based pricing (pay-as-you-go)", Difficulty = 2
                },
                new Question
                {
                    Id = 7,
                    Text = "If a cloud provider is responsible for managing the operating system, runtime, and application platform, while the customer is responsible for the application code and data, what service model is being used?",
                    Options = new List<string> { "A) IaaS", "B) PaaS", "C) SaaS", "D) On-premises" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) PaaS", Difficulty = 1
                },
                new Question
                {
                    Id = 8,
                    Text = "Which term describes the cloud computing principle where resources are pooled to serve multiple consumers, with different physical and virtual resources dynamically assigned according to demand?",
                    Options = new List<string> { "A) Broad network access", "B) Resource pooling", "C) Rapid elasticity", "D) Measured service" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Resource pooling", Difficulty = 2
                },
                new Question
                {
                    Id = 9,
                    Text = "For which scenario would a *hybrid* cloud deployment be the *least* appropriate?",
                    Options = new List<string> { "A) Running a legacy application that cannot be moved from an on-premises server due to regulatory constraints.", "B) Hosting a public-facing website with highly variable traffic.", "C) Using cloud-based analytics services to process data collected from on-premises sensors.", "D) Maintaining an active directory domain on-premises while synchronizing identities with the cloud." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Hosting a public-facing website with highly variable traffic.", Difficulty = 3
                },
                new Question
                {
                    Id = 10,
                    Text = "Which statement BEST describes the economic advantage of moving from a CapEx to an OpEx model with cloud computing?",
                    Options = new List<string> { "A) It requires a larger upfront investment but reduces long-term costs.", "B) It converts capital expenses into predictable operational expenses, improving cash flow.", "C) It eliminates all IT spending related to infrastructure.", "D) It guarantees that the total cost of ownership (TCO) will always be lower." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) It converts capital expenses into predictable operational expenses, improving cash flow.", Difficulty = 2
                },
                new Question
                {
                    Id = 11,
                    Text = "A development team needs to quickly provision several identical testing environments, use them for a week, and then decommission them. Which cloud characteristic provides the greatest benefit in this case?",
                    Options = new List<string> { "A) High availability", "B) Disaster recovery", "C) Agility", "D) Latency optimization" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Agility", Difficulty = 2
                },
                new Question
                {
                    Id = 12,
                    Text = "In the shared responsibility model for *IaaS*, which of the following is typically the responsibility of the cloud provider?",
                    Options = new List<string> { "A) Securing the network traffic within the virtual network.", "B) Patching the operating system on the virtual machines.", "C) Maintaining the physical security of the datacenter.", "D) Managing the access permissions for the application users." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Maintaining the physical security of the datacenter.", Difficulty = 1
                },
                new Question
                {
                    Id = 13,
                    Text = "What is the primary purpose of an Availability Zone in Azure?",
                    Options = new List<string> { "A) To replicate data to a different geographic region for disaster recovery.", "B) To provide a geographically separate group of datacenters within a single region for high availability.", "C) To organize resources for billing and access management.", "D) To offer discounted pricing for non-critical workloads." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To provide a geographically separate group of datacenters within a single region for high availability.", Difficulty = 2
                },
                new Question
                {
                    Id = 14,
                    Text = "Which Azure feature allows you to logically group multiple subscriptions to apply governance policies and access controls collectively?",
                    Options = new List<string> { "A) Resource Group", "B) Management Group", "C) Tenant", "D) Availability Set" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Management Group", Difficulty = 2
                },
                new Question
                {
                    Id = 15,
                    Text = "You have an Azure subscription. You need to ensure that new resources can only be deployed in specific regions like 'West Europe' or 'North Central US' to comply with data residency laws. What should you use?",
                    Options = new List<string> { "A) Azure Policy", "B) Resource Locks", "C) Azure Blueprints", "D) Cost Management" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) Azure Policy", Difficulty = 2
                },
                new Question
                {
                    Id = 16,
                    Text = "Which Azure compute service is BEST described as a 'serverless' offering where you deploy individual functions that run in response to events without managing any infrastructure?",
                    Options = new List<string> { "A) Azure Virtual Machines", "B) Azure App Service", "C) Azure Kubernetes Service (AKS)", "D) Azure Functions" },
                    CorrectAnswer = "D", CorrectAnswerText = "D) Azure Functions", Difficulty = 1
                },
                new Question
                {
                    Id = 17,
                    Text = "For storing unstructured data such as text or binary data (e.g., videos, images, backup files), which Azure storage service is the most cost-effective and appropriate?",
                    Options = new List<string> { "A) Azure Files", "B) Azure Blob Storage", "C) Azure Table Storage", "D) Azure Queues" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Blob Storage", Difficulty = 1
                },
                new Question
                {
                    Id = 18,
                    Text = "Which Azure networking service is a load balancer that works at the *application layer* (OSI layer 7) and can make routing decisions based on URL paths or host headers?",
                    Options = new List<string> { "A) Azure Load Balancer (Standard)", "B) Azure Application Gateway", "C) Azure Traffic Manager", "D) Azure VPN Gateway" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Application Gateway", Difficulty = 3
                },
                new Question
                {
                    Id = 19,
                    Text = "In the Azure pricing model, what is the primary benefit of purchasing a 'Reserved Instance' for a virtual machine?",
                    Options = new List<string> { "A) It provides a dedicated physical server for better performance.", "B) It guarantees the VM will never be rebooted for host maintenance.", "C) It offers a significant discount (up to 72%) compared to pay-as-you-go pricing for a committed term (1 or 3 years).", "D) It allows unlimited scaling of the VM without additional cost." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) It offers a significant discount (up to 72%) compared to pay-as-you-go pricing for a committed term (1 or 3 years).", Difficulty = 1
                },
                new Question
                {
                    Id = 20,
                    Text = "Which Azure service provides a unified dashboard for monitoring the security posture of your Azure, hybrid, and multi-cloud resources, and provides security recommendations?",
                    Options = new List<string> { "A) Azure Monitor", "B) Azure Advisor", "C) Microsoft Defender for Cloud (formerly Azure Security Center)", "D) Azure Policy" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Microsoft Defender for Cloud (formerly Azure Security Center)", Difficulty = 2
                },

                // ==================== БЛОК 2 (Вопросы 21-40) — Архитектура, сервисы и управление ====================
                new Question
                {
                    Id = 21,
                    Text = "You are designing an application that requires a relational database. Your team wants to minimize administrative overhead for tasks like patching, backups, and high-availability configuration. Which Azure service should you recommend?",
                    Options = new List<string> { "A) Install SQL Server on an Azure Virtual Machine.", "B) Use Azure SQL Database.", "C) Use Azure Cosmos DB with the SQL API.", "D) Use Azure Database for PostgreSQL." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Use Azure SQL Database.", Difficulty = 2
                },
                new Question
                {
                    Id = 22,
                    Text = "Which Azure service is a fully managed platform for building, training, and deploying machine learning models using a visual drag-and-drop interface or code-based notebooks?",
                    Options = new List<string> { "A) Azure Cognitive Services", "B) Azure Machine Learning", "C) Azure Databricks", "D) Azure Analysis Services" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Machine Learning", Difficulty = 2
                },
                new Question
                {
                    Id = 23,
                    Text = "A company needs to collect telemetry data from thousands of IoT devices (sensors) securely, and then process and route that data to other Azure services. Which Azure service is the central message hub designed specifically for this IoT scenario?",
                    Options = new List<string> { "A) Azure Event Grid", "B) Azure Notification Hubs", "C) Azure IoT Hub", "D) Azure Service Bus" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure IoT Hub", Difficulty = 2
                },
                new Question
                {
                    Id = 24,
                    Text = "In the context of Azure costs, what is the primary purpose of applying *tags* to resources?",
                    Options = new List<string> { "A) To automatically shut down resources during non-business hours.", "B) To group resources for billing and cost analysis by department, project, or cost center.", "C) To increase the performance of the tagged resources.", "D) To enforce geographic compliance policies." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To group resources for billing and cost analysis by department, project, or cost center.", Difficulty = 1
                },
                new Question
                {
                    Id = 25,
                    Text = "Your Azure virtual machine needs to securely access a password or a connection string stored in Azure. Which service should you use to store and manage these secrets?",
                    Options = new List<string> { "A) Azure Storage Account with encryption enabled", "B) Azure Information Protection", "C) Azure Key Vault", "D) Azure Security Center's secure storage" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Key Vault", Difficulty = 1
                },
                new Question
                {
                    Id = 26,
                    Text = "Which of the following statements about Azure Resource Manager (ARM) templates is TRUE?",
                    Options = new List<string> { "A) They are written in imperative code (like PowerShell) to define deployment steps.", "B) They are used only for deploying virtual machines.", "C) They define the desired state of infrastructure and resources using JSON declarative syntax.", "D) They cannot be version-controlled or integrated into CI/CD pipelines." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) They define the desired state of infrastructure and resources using JSON declarative syntax.", Difficulty = 2
                },
                new Question
                {
                    Id = 27,
                    Text = "For a globally distributed web application, you need a service that will route user requests to the closest healthy backend endpoint based on the user's geographic location. This service should work at the DNS level. Which Azure service should you use?",
                    Options = new List<string> { "A) Azure Front Door", "B) Azure Application Gateway", "C) Azure Traffic Manager", "D) Azure Load Balancer" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Traffic Manager", Difficulty = 3
                },
                new Question
                {
                    Id = 28,
                    Text = "Which Azure tool provides a browser-based command-line experience that combines both Azure PowerShell and Azure CLI, and persists file storage across sessions?",
                    Options = new List<string> { "A) Azure Portal", "B) Azure Cloud Shell", "C) Azure SDK", "D) Windows Terminal with Azure modules" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Cloud Shell", Difficulty = 1
                },
                new Question
                {
                    Id = 29,
                    Text = "You have an Azure subscription. You need to ensure that if a resource is deleted accidentally, it cannot be deleted for a certain period. What should you implement?",
                    Options = new List<string> { "A) An Azure Policy with a 'DenyDelete' effect.", "B) A Resource Lock with the 'CanNotDelete' setting.", "C) Azure Advisor recommendation to enable soft delete.", "D) Role-Based Access Control (RBAC) to remove delete permissions." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) A Resource Lock with the 'CanNotDelete' setting.", Difficulty = 2
                },
                new Question
                {
                    Id = 30,
                    Text = "A company plans to migrate a large on-premises archive of media files (totaling 500 TB) to Azure Blob Storage. The internet connection is slow and unreliable. Which Azure service is designed for secure, large-scale offline data transfer in this scenario?",
                    Options = new List<string> { "A) Azure Import/Export service (ship physical disks)", "B) Azure Data Factory", "C) AzCopy over the internet", "D) Azure StorSimple" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) Azure Import/Export service (ship physical disks)", Difficulty = 2
                },
                new Question
                {
                    Id = 31,
                    Text = "What is the primary difference between Azure Service Level Agreement (SLA) for a single Virtual Machine (with no availability features) and an SLA for a Virtual Machine deployed in an Availability Set?",
                    Options = new List<string> { "A) The SLA for a VM in an Availability Set is always 100%.", "B) The SLA for a single VM is higher because it has fewer points of failure.", "C) The SLA for a VM in an Availability Set is higher because it provides protection against hardware failures and planned maintenance within a datacenter.", "D) There is no difference; both have the same SLA." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) The SLA for a VM in an Availability Set is higher because it provides protection against hardware failures and planned maintenance within a datacenter.", Difficulty = 3
                },
                new Question
                {
                    Id = 32,
                    Text = "Which Azure networking concept allows you to create a private, dedicated connection between your on-premises network and an Azure Virtual Network without sending traffic over the public internet?",
                    Options = new List<string> { "A) A Site-to-Site (S2S) VPN", "B) A Point-to-Site (P2S) VPN", "C) Azure ExpressRoute", "D) VNet Peering" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure ExpressRoute", Difficulty = 2
                },
                new Question
                {
                    Id = 33,
                    Text = "When you create a new Azure resource, such as a virtual machine, into which fundamental Azure construct *must* you deploy it?",
                    Options = new List<string> { "A) A Region", "B) A Subscription", "C) A Resource Group", "D) A Management Group" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) A Resource Group", Difficulty = 2
                },
                new Question
                {
                    Id = 34,
                    Text = "Which Azure service provides built-in autoscaling for a web application based on metrics like CPU usage or schedule, without requiring you to manage the underlying VMs?",
                    Options = new List<string> { "A) Azure Virtual Machine Scale Sets", "B) Azure App Service", "C) Azure Container Instances", "D) Azure Kubernetes Service (AKS)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure App Service", Difficulty = 3
                },
                new Question
                {
                    Id = 35,
                    Text = "In the Azure shared responsibility model, who is responsible for securing the *network traffic* between Azure virtual machines within the same virtual network?",
                    Options = new List<string> { "A) Microsoft", "B) The customer", "C) It is a shared responsibility.", "D) The responsibility depends on the VM's operating system." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) The customer", Difficulty = 2
                },
                new Question
                {
                    Id = 36,
                    Text = "What is the main purpose of the 'Azure Advisor' service?",
                    Options = new List<string> { "A) To monitor application performance and diagnose issues.", "B) To provide personalized recommendations for optimizing Azure resources in terms of cost, performance, security, and reliability.", "C) To enforce corporate governance policies across subscriptions.", "D) To automatically apply the latest security patches to virtual machines." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To provide personalized recommendations for optimizing Azure resources in terms of cost, performance, security, and reliability.", Difficulty = 1
                },
                new Question
                {
                    Id = 37,
                    Text = "You need to deploy a containerized application quickly without managing any orchestrator, clusters, or virtual machines. Which Azure compute service should you choose?",
                    Options = new List<string> { "A) Azure Kubernetes Service (AKS)", "B) Azure Container Instances (ACI)", "C) Azure App Service for Containers", "D) Azure Virtual Machines with Docker" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Container Instances (ACI)", Difficulty = 2
                },
                new Question
                {
                    Id = 38,
                    Text = "Which feature of Azure Virtual Networks allows you to divide a VNet into multiple isolated subnets, each with its own IP address range?",
                    Options = new List<string> { "A) Network Security Groups (NSGs)", "B) VNet Peering", "C) Subnetting", "D) User-Defined Routes (UDRs)" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Subnetting", Difficulty = 1
                },
                new Question
                {
                    Id = 39,
                    Text = "What is the primary use case for Azure Content Delivery Network (CDN)?",
                    Options = new List<string> { "A) To store large amounts of unstructured data globally.", "B) To deliver high-bandwidth static and dynamic web content to users with low latency by caching it at edge locations.", "C) To provide a global load balancing solution for web applications.", "D) To encrypt web traffic between the user and the application." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To deliver high-bandwidth static and dynamic web content to users with low latency by caching it at edge locations.", Difficulty = 1
                },
                new Question
                {
                    Id = 40,
                    Text = "When using Azure Monitor, which data type typically represents a point-in-time measurement of a resource's condition (e.g., CPU percentage, available memory)?",
                    Options = new List<string> { "A) Logs", "B) Metrics", "C) Traces", "D) Alerts" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Metrics", Difficulty = 2
                },

                // ==================== БЛОК 3 (Вопросы 41-60) — Сложные сценарии, безопасность ====================
                new Question
                {
                    Id = 41,
                    Text = "A company is deploying a mission-critical application on Azure. The requirements state that the application must remain available even if an entire Azure datacenter fails due to a natural disaster. Which combination of Azure features provides the highest level of *resiliency*?",
                    Options = new List<string> { "A) Deploy the application within a single Availability Zone.", "B) Deploy the application across multiple Virtual Machines in an Availability Set.", "C) Deploy the application across multiple Virtual Machines in different Availability Zones within the same region.", "D) Deploy the application across multiple Virtual Machines in two different Azure regions." },
                    CorrectAnswer = "D", CorrectAnswerText = "D) Deploy the application across multiple Virtual Machines in two different Azure regions.", Difficulty = 3
                },
                new Question
                {
                    Id = 42,
                    Text = "Under the shared responsibility model, which task is always the responsibility of the customer, regardless of whether they are using IaaS, PaaS, or SaaS?",
                    Options = new List<string> { "A) Securing the physical hosts and network devices.", "B) Managing and protecting their own data and information.", "C) Patching the host operating system for virtual machines.", "D) Configuring the network firewall appliances in the datacenter." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Managing and protecting their own data and information.", Difficulty = 2
                },
                new Question
                {
                    Id = 43,
                    Text = "You are implementing governance across multiple Azure subscriptions. You need to ensure that all storage accounts across all subscriptions have encryption enabled and that no storage accounts are created with public access. Which Azure service should you use to enforce these rules?",
                    Options = new List<string> { "A) Azure Role-Based Access Control (RBAC)", "B) Azure Resource Locks", "C) Azure Policy", "D) Microsoft Defender for Cloud" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Policy", Difficulty = 3
                },
                new Question
                {
                    Id = 44,
                    Text = "Which Azure service helps protect against Distributed Denial of Service (DDoS) attacks by automatically detecting and mitigating network-level attacks on your Azure resources?",
                    Options = new List<string> { "A) Azure Firewall", "B) Network Security Groups (NSG)", "C) Azure DDoS Protection Standard", "D) Web Application Firewall (WAF) on Application Gateway" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure DDoS Protection Standard", Difficulty = 2
                },
                new Question
                {
                    Id = 45,
                    Text = "A company wants to use a cloud service that provides a fully managed, globally distributed NoSQL database with guaranteed low-latency reads and writes, and automatic scaling. Which Azure service meets these requirements?",
                    Options = new List<string> { "A) Azure SQL Database", "B) Azure Database for PostgreSQL", "C) Azure Cosmos DB", "D) Azure Cache for Redis" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Cosmos DB", Difficulty = 2
                },
                new Question
                {
                    Id = 46,
                    Text = "Which statement accurately describes the difference between Azure Active Directory (Azure AD) Free and Azure AD Premium P1/P2 licenses in the context of security?",
                    Options = new List<string> { "A) Azure AD Free does not support single sign-on (SSO) for any applications.", "B) Azure AD Premium licenses provide advanced identity protection and conditional access policies, while Azure AD Free has basic security features.", "C) Azure AD Free includes self-service password reset for all users, while Premium does not.", "D) Multi-factor authentication (MFA) is only available with Azure AD Premium licenses." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure AD Premium licenses provide advanced identity protection and conditional access policies, while Azure AD Free has basic security features.", Difficulty = 3
                },
                new Question
                {
                    Id = 47,
                    Text = "You need to provide a developer with the ability to create and manage Azure Storage Accounts and Virtual Networks in a specific Resource Group, but not allow them to delete the Resource Group itself or manage access permissions for others. Which built-in RBAC role is most appropriate?",
                    Options = new List<string> { "A) Owner", "B) Contributor", "C) Reader", "D) Storage Account Contributor" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Contributor", Difficulty = 3
                },
                new Question
                {
                    Id = 48,
                    Text = "Which Azure service can be used to create a visual map of the dependencies between application components hosted on Azure VMs, App Services, and external dependencies, helping to diagnose performance issues?",
                    Options = new List<string> { "A) Azure Service Health", "B) Azure Monitor Log Analytics", "C) Azure Application Insights", "D) Azure Network Watcher" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Application Insights", Difficulty = 3
                },
                new Question
                {
                    Id = 49,
                    Text = "According to Microsoft, who can access customer data stored in Azure?",
                    Options = new List<string> { "A) Microsoft support engineers can access data at any time for maintenance purposes.", "B) Selected Microsoft personnel may access data only under limited circumstances with explicit customer consent or for troubleshooting at the customer's request.", "C) No one from Microsoft can ever access customer data under any circumstances.", "D) Microsoft uses automated systems to scan all customer data for security threats, and engineers review flagged content." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Selected Microsoft personnel may access data only under limited circumstances with explicit customer consent or for troubleshooting at the customer's request.", Difficulty = 3
                },
                new Question
                {
                    Id = 50,
                    Text = "What is the primary purpose of an Azure *Subscription* from a billing and resource management perspective?",
                    Options = new List<string> { "A) To define a geographic boundary for resource deployment.", "B) To act as a logical container for Azure resources and provide a unified billing boundary.", "C) To enforce network security policies between development and production environments.", "D) To group users and applications for identity management." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To act as a logical container for Azure resources and provide a unified billing boundary.", Difficulty = 2
                },
                new Question
                {
                    Id = 51,
                    Text = "You are deploying a stateless web application that will experience unpredictable, rapid spikes in traffic. You need a hosting solution that automatically scales with no administrative overhead for infrastructure management. Cost efficiency during low-traffic periods is critical. Which Azure compute service is MOST suitable?",
                    Options = new List<string> { "A) Azure Virtual Machines with Auto Scaling configured.", "B) Azure App Service with Autoscale enabled.", "C) Azure Kubernetes Service (AKS) with cluster autoscaler.", "D) Azure Container Instances (ACI)." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure App Service with Autoscale enabled.", Difficulty = 4
                },
                new Question
                {
                    Id = 52,
                    Text = "Which type of Azure support request can be used to request a quota increase for a particular service (e.g., more vCPUs per region)?",
                    Options = new List<string> { "A) Technical support", "B) Billing support", "C) Subscription management", "D) Service and subscription limits (quotas)" },
                    CorrectAnswer = "D", CorrectAnswerText = "D) Service and subscription limits (quotas)", Difficulty = 2
                },
                new Question
                {
                    Id = 53,
                    Text = "In Azure, what is the relationship between a *Tenant* (Azure AD Tenant) and a *Subscription*?",
                    Options = new List<string> { "A) A single subscription can be associated with multiple tenants.", "B) A single tenant can be associated with multiple subscriptions, but a subscription can belong to only one tenant.", "C) A tenant and a subscription are the same thing.", "D) A subscription is required to create a tenant, but a tenant is not required for a subscription." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) A single tenant can be associated with multiple subscriptions, but a subscription can belong to only one tenant.", Difficulty = 3
                },
                new Question
                {
                    Id = 54,
                    Text = "Which Azure service provides a unified, centralized platform for managing secrets, encryption keys, and digital certificates across your applications and services?",
                    Options = new List<string> { "A) Azure Security Center", "B) Azure Information Protection", "C) Azure Key Vault", "D) Azure Dedicated HSM" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Key Vault", Difficulty = 1
                },
                new Question
                {
                    Id = 55,
                    Text = "You need to ensure that all Azure Virtual Machines in your environment have the latest critical security patches applied to their operating systems. According to the shared responsibility model, who is responsible for applying these patches in an IaaS scenario?",
                    Options = new List<string> { "A) Microsoft automatically applies all patches to guest OS.", "B) The customer is responsible for applying patches to the guest OS.", "C) It is a shared responsibility; Microsoft patches the host, customer patches the guest.", "D) Microsoft provides a list of patches, and the customer must approve them before application." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) The customer is responsible for applying patches to the guest OS.", Difficulty = 2
                },
                new Question
                {
                    Id = 56,
                    Text = "Which Azure tool would you use to get an estimated monthly cost for a proposed architecture before deploying any resources?",
                    Options = new List<string> { "A) Azure Cost Management + Billing", "B) Azure Pricing Calculator", "C) Azure Advisor Cost Recommendations", "D) Total Cost of Ownership (TCO) Calculator" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Pricing Calculator", Difficulty = 2
                },
                new Question
                {
                    Id = 57,
                    Text = "What is the main benefit of using *Managed Disks* for Azure Virtual Machines compared to unmanaged (storage account) disks?",
                    Options = new List<string> { "A) Managed Disks are always cheaper.", "B) Managed Disks simplify disk management by handling storage accounts automatically and provide better reliability with availability sets.", "C) Managed Disks offer higher performance at all tiers.", "D) Managed Disks allow you to directly access the underlying storage account for advanced configurations." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Managed Disks simplify disk management by handling storage accounts automatically and provide better reliability with availability sets.", Difficulty = 2
                },
                new Question
                {
                    Id = 58,
                    Text = "Which Azure networking feature allows two Azure Virtual Networks to connect directly and securely, enabling resources in different VNets to communicate as if they are on the same network?",
                    Options = new List<string> { "A) VNet-to-VNet VPN Gateway", "B) VNet Peering", "C) Azure ExpressRoute", "D) Network Security Groups (NSG)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) VNet Peering", Difficulty = 2
                },
                new Question
                {
                    Id = 59,
                    Text = "You receive a notification from 'Service Health' in the Azure portal. This notification most likely concerns:",
                    Options = new List<string> { "A) A performance issue in your specific Azure SQL database.", "B) A planned maintenance event or an ongoing incident affecting Azure services in a region you are using.", "C) A security vulnerability detected in one of your virtual machines.", "D) A recommendation to resize an underutilized virtual machine to save costs." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) A planned maintenance event or an ongoing incident affecting Azure services in a region you are using.", Difficulty = 2
                },
                new Question
                {
                    Id = 60,
                    Text = "A company wants to ensure that if an Azure region becomes unavailable, their application can be failed over to another region with minimal data loss. Which Azure feature should they implement for their Azure SQL Database to meet this requirement?",
                    Options = new List<string> { "A) Geo-redundant storage (GRS)", "B) Auto-failover groups", "C) Read-scale replicas", "D) Local redundant storage (LRS)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Auto-failover groups", Difficulty = 3
                },

                // ==================== БЛОК 4 (Вопросы 61-80) ====================
                new Question
                {
                    Id = 61,
                    Text = "A company runs a monolithic .NET Framework 4.8 application on-premises. They want to migrate it to Azure with minimal code changes and retain full control over the Windows Server operating system for specific legacy dependencies. Which Azure compute service is the *most suitable* initial landing point?",
                    Options = new List<string> { "A) Azure App Service", "B) Azure Kubernetes Service (AKS)", "C) Azure Virtual Machines", "D) Azure Container Instances (ACI)" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Virtual Machines", Difficulty = 2
                },
                new Question
                {
                    Id = 62,
                    Text = "Which Azure service is primarily designed to help you prevent, detect, and respond to security threats with advanced, cloud-native security analytics across your Azure, hybrid, and multi-cloud resources?",
                    Options = new List<string> { "A) Azure Sentinel", "B) Microsoft Defender for Cloud", "C) Azure Policy", "D) Azure Key Vault" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Microsoft Defender for Cloud", Difficulty = 3
                },
                new Question
                {
                    Id = 63,
                    Text = "You are deploying a new Azure SQL Database. The compliance requirements state that in the event of a regional outage, the database must fail over to a secondary region automatically with an RPO (Recovery Point Objective) of less than 5 seconds. Which feature must you configure?",
                    Options = new List<string> { "A) Geo-replication", "B) Auto-failover groups", "C) Read-scale replicas", "D) Active geo-replication with automatic failover policy" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Auto-failover groups", Difficulty = 4
                },
                new Question
                {
                    Id = 64,
                    Text = "What is the main characteristic of a *serverless* compute service like Azure Functions?",
                    Options = new List<string> { "A) It runs on dedicated physical servers for maximum performance.", "B) You never have to write any code for the application.", "C) The cloud provider dynamically manages the allocation and scaling of the underlying infrastructure; you only manage your code and pay per execution.", "D) It requires you to pre-purchase compute capacity for one or three years." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) The cloud provider dynamically manages the allocation and scaling of the underlying infrastructure; you only manage your code and pay per execution.", Difficulty = 2
                },
                new Question
                {
                    Id = 65,
                    Text = "In the context of Azure networking, what is the primary purpose of a *Network Security Group (NSG)*?",
                    Options = new List<string> { "A) To provide a private, dedicated connection between an on-premises network and Azure.", "B) To filter network traffic to and from Azure resources within a Virtual Network by defining rules based on source/destination IP, port, and protocol.", "C) To distribute incoming internet traffic across multiple virtual machines.", "D) To translate between private and public IP addresses for outbound internet connectivity." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To filter network traffic to and from Azure resources within a Virtual Network by defining rules based on source/destination IP, port, and protocol.", Difficulty = 2
                },
                new Question
                {
                    Id = 66,
                    Text = "Your company has a policy that all development and testing resources must be automatically shut down every day at 7 PM and started again at 7 AM to minimize costs. Which Azure service can help automate this schedule without writing custom scripts?",
                    Options = new List<string> { "A) Azure Logic Apps", "B) Azure Automation with runbooks", "C) Azure Cost Management budgets", "D) Azure Advisor" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Automation with runbooks", Difficulty = 3
                },
                new Question
                {
                    Id = 67,
                    Text = "Which of the following statements best describes the *Total Cost of Ownership (TCO) Calculator*?",
                    Options = new List<string> { "A) It provides a detailed forecast of monthly Azure spend for a specific architecture.", "B) It compares the costs of running an on-premises infrastructure versus running an equivalent workload in Azure over time.", "C) It analyzes your current Azure usage and recommends immediate cost-saving actions.", "D) It allows you to set spending limits and alerts for your Azure subscriptions." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) It compares the costs of running an on-premises infrastructure versus running an equivalent workload in Azure over time.", Difficulty = 2
                },
                new Question
                {
                    Id = 68,
                    Text = "A RESTful API and a SOAP-based web service are both being considered for a new microservice. Which of the following is a distinct advantage of the RESTful API in a cloud-native environment?",
                    Options = new List<string> { "A) Built-in support for complex, stateful transactions across multiple services.", "B) Native ability to leverage HTTP caching mechanisms for improved performance and reduced load.", "C) Mandatory, strong typing of all data exchanges via a formal contract (WSDL).", "D) Integrated message-level security standards (WS-Security) out of the box." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Native ability to leverage HTTP caching mechanisms for improved performance and reduced load.", Difficulty = 3
                },
                new Question
                {
                    Id = 69,
                    Text = "You need to deploy a containerized application that requires persistent storage, automatic scaling, and service discovery between multiple containers. You do not want to manage the Kubernetes control plane (master nodes). Which Azure service should you choose?",
                    Options = new List<string> { "A) Azure Container Instances (ACI)", "B) Azure App Service for Containers", "C) Azure Kubernetes Service (AKS)", "D) Azure Virtual Machines with Docker Engine" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Kubernetes Service (AKS)", Difficulty = 4
                },
                new Question
                {
                    Id = 70,
                    Text = "According to the shared responsibility model, when using Azure SQL Database (PaaS), who is responsible for applying security updates and patches to the underlying SQL Server database engine?",
                    Options = new List<string> { "A) The customer", "B) Microsoft", "C) Shared responsibility: Microsoft provides the patch, the customer applies it.", "D) It depends on the service tier (Basic, Standard, Premium)." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Microsoft", Difficulty = 2
                },
                new Question
                {
                    Id = 71,
                    Text = "Which Azure cost management tool provides *personalized recommendations* to optimize your Azure spending, such as resizing underutilized virtual machines or purchasing reserved instances?",
                    Options = new List<string> { "A) Azure Pricing Calculator", "B) Azure Cost Management + Billing's cost analysis", "C) Azure Advisor (Cost blade)", "D) Total Cost of Ownership (TCO) Calculator" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Advisor (Cost blade)", Difficulty = 2
                },
                new Question
                {
                    Id = 72,
                    Text = "What is the primary purpose of Azure Blueprints?",
                    Options = new List<string> { "A) To visually diagram your application architecture before deployment.", "B) To define a repeatable set of governance resources and policies (like RBAC, Policy, ARM templates) that can be deployed together to standardize environments.", "C) To create a detailed project plan for migrating workloads to Azure.", "D) To generate compliance reports for auditing purposes." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To define a repeatable set of governance resources and policies (like RBAC, Policy, ARM templates) that can be deployed together to standardize environments.", Difficulty = 3
                },
                new Question
                {
                    Id = 73,
                    Text = "In a hybrid cloud scenario, which Azure service can provide a unified identity and access management platform, allowing users to securely sign in to both on-premises applications and cloud services like Office 365 with the same credentials?",
                    Options = new List<string> { "A) Azure Active Directory (Azure AD)", "B) Azure RBAC", "C) Azure Policy", "D) On-premises Active Directory Domain Services only" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) Azure Active Directory (Azure AD)", Difficulty = 2
                },
                new Question
                {
                    Id = 74,
                    Text = "A container image contains your web application and its dependencies. What does a *container orchestration* platform, like Kubernetes (e.g., Azure Kubernetes Service - AKS), primarily manage?",
                    Options = new List<string> { "A) The source code of the application inside the container.", "B) The lifecycle, scaling, networking, and availability of multiple containers across a cluster of nodes.", "C) The security patches for the operating system inside each container.", "D) The development environment for building the container image." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) The lifecycle, scaling, networking, and availability of multiple containers across a cluster of nodes.", Difficulty = 2
                },
                new Question
                {
                    Id = 75,
                    Text = "You are designing an application that will have a front-end web app and a back-end database. You want to ensure that the database is not accessible directly from the internet, but only from the web app. Which Azure networking concept should you use?",
                    Options = new List<string> { "A) Place both the web app and the database in the same Availability Zone.", "B) Deploy the database in a different subscription.", "C) Place the database in a private subnet and the web app in a public subnet within the same Virtual Network, using Network Security Groups (NSGs) to restrict traffic.", "D) Use Azure Front Door in front of the database." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Place the database in a private subnet and the web app in a public subnet within the same Virtual Network, using Network Security Groups (NSGs) to restrict traffic.", Difficulty = 3
                },
                new Question
                {
                    Id = 76,
                    Text = "Which statement accurately describes a key difference between Azure DevOps and GitHub in the context of Azure services?",
                    Options = new List<string> { "A) Azure DevOps is only for CI/CD pipelines, while GitHub is only for source code repository.", "B) Both offer similar core services (repos, pipelines, boards), but Azure DevOps is more tightly integrated with Azure for deployment and management, while GitHub is broader and now owned by Microsoft.", "C) GitHub cannot be integrated with Azure services at all.", "D) Azure DevOps is a Microsoft product, while GitHub is an open-source platform not supported by Microsoft." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Both offer similar core services (repos, pipelines, boards), but Azure DevOps is more tightly integrated with Azure for deployment and management, while GitHub is broader and now owned by Microsoft.", Difficulty = 3
                },
                new Question
                {
                    Id = 77,
                    Text = "If you need to run a workload that requires a specific, non-standard version of a Linux kernel module or direct access to hardware virtualization features, which Azure compute option gives you the *highest level of control*?",
                    Options = new List<string> { "A) Azure App Service", "B) Azure Virtual Machines", "C) Azure Container Instances", "D) Azure Functions" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Virtual Machines", Difficulty = 2
                },
                new Question
                {
                    Id = 78,
                    Text = "What is the *primary benefit* of using the Azure Spot Virtual Machines pricing model?",
                    Options = new List<string> { "A) Guaranteed availability and no risk of eviction.", "B) Significant cost savings (up to 90%) for interruptible workloads like batch processing, rendering, or testing.", "C) Dedicated physical isolation from other customers' VMs.", "D) Automatic scaling based on CPU load." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Significant cost savings (up to 90%) for interruptible workloads like batch processing, rendering, or testing.", Difficulty = 2
                },
                new Question
                {
                    Id = 79,
                    Text = "For a globally distributed SaaS application, which combination of Azure services would best provide low-latency access to static content (images, CSS, JS) for users worldwide and protect the application from common web exploits like SQL injection?",
                    Options = new List<string> { "A) Azure Traffic Manager + Azure SQL Database", "B) Azure Content Delivery Network (CDN) + Web Application Firewall (WAF) on Azure Front Door/Application Gateway", "C) Azure Load Balancer + Azure DDoS Protection", "D) Azure ExpressRoute + Azure Firewall" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Content Delivery Network (CDN) + Web Application Firewall (WAF) on Azure Front Door/Application Gateway", Difficulty = 3
                },
                new Question
                {
                    Id = 80,
                    Text = "In the context of cloud economics, what does the term 'Economies of Scale' refer to from the perspective of a cloud provider like Microsoft?",
                    Options = new List<string> { "A) The ability for a single customer to reduce their costs by using more services.", "B) The cost advantage that a large provider gains due to its ability to purchase and operate massive, efficient datacenters, which results in lower prices for customers.", "C) The practice of scaling down resources during off-peak hours to save money.", "D) The discount offered when a customer commits to using a service for 1 or 3 years (Reserved Instances)." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) The cost advantage that a large provider gains due to its ability to purchase and operate massive, efficient datacenters, which results in lower prices for customers.", Difficulty = 3
                },

                // ==================== БЛОК 5 (Вопросы 81-100) ====================
                new Question
                {
                    Id = 81,
                    Text = "Which Azure service provides a fully managed identity service with seamless single sign-on (SSO) to thousands of pre-integrated SaaS applications like Salesforce, Slack, and Dropbox?",
                    Options = new List<string> { "A) Azure Active Directory (Azure AD)", "B) Azure AD Domain Services", "C) Azure RBAC", "D) Azure Information Protection" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) Azure Active Directory (Azure AD)", Difficulty = 2
                },
                new Question
                {
                    Id = 82,
                    Text = "You need to store application secrets like database connection strings. Which Azure service is specifically designed for secure storage and retrieval of such secrets, and also provides automatic rotation for secrets and keys?",
                    Options = new List<string> { "A) Azure Storage Account with encryption enabled", "B) Azure SQL Database with Transparent Data Encryption (TDE)", "C) Azure Key Vault", "D) Azure Security Center secure storage" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Key Vault", Difficulty = 2
                },
                new Question
                {
                    Id = 83,
                    Text = "Which Azure compute service is specifically designed to run event-driven, serverless code that automatically scales and charges you only for the time your code is executing?",
                    Options = new List<string> { "A) Azure Virtual Machines", "B) Azure App Service", "C) Azure Functions", "D) Azure Kubernetes Service (AKS)" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Functions", Difficulty = 1
                },
                new Question
                {
                    Id = 84,
                    Text = "What is the primary purpose of Azure Resource Manager (ARM) templates?",
                    Options = new List<string> { "A) To write procedural scripts for deploying resources", "B) To define the desired state of your Azure infrastructure using declarative JSON syntax", "C) To monitor the performance of deployed resources", "D) To set up alerts for resource costs" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To define the desired state of your Azure infrastructure using declarative JSON syntax", Difficulty = 2
                },
                new Question
                {
                    Id = 85,
                    Text = "Which Azure networking service provides DDoS protection at the network layer (layers 3 and 4) automatically for all Azure customers, without any additional cost?",
                    Options = new List<string> { "A) Azure Firewall", "B) Azure DDoS Protection Basic", "C) Azure DDoS Protection Standard", "D) Network Security Groups (NSGs)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure DDoS Protection Basic", Difficulty = 2
                },
                new Question
                {
                    Id = 86,
                    Text = "You need to ensure that developers in your company can only create virtual machines of specific sizes (e.g., Standard_D2s_v3) and cannot create the most expensive sizes. Which Azure governance service should you use?",
                    Options = new List<string> { "A) Azure Cost Management", "B) Azure Policy", "C) Resource Locks", "D) Azure Advisor" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Policy", Difficulty = 2
                },
                new Question
                {
                    Id = 87,
                    Text = "Which of the following is a key characteristic of the public cloud deployment model?",
                    Options = new List<string> { "A) Resources are dedicated to a single organization", "B) Resources are shared among multiple organizations (multi-tenant)", "C) Requires capital expenditure (CapEx) for hardware", "D) Provides the highest level of physical control over data" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Resources are shared among multiple organizations (multi-tenant)", Difficulty = 1
                },
                new Question
                {
                    Id = 88,
                    Text = "What is the main benefit of using Azure Automanage for virtual machines?",
                    Options = new List<string> { "A) It automatically migrates VMs to the cloud", "B) It automatically applies best practices for monitoring, backup, and security across the VM lifecycle", "C) It automatically shuts down VMs when they are not in use", "D) It automatically converts VMs to containers" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) It automatically applies best practices for monitoring, backup, and security across the VM lifecycle", Difficulty = 3
                },
                new Question
                {
                    Id = 89,
                    Text = "Which Azure service provides a globally distributed, multi-model database that supports document, key-value, graph, and column-family data models with turnkey global distribution?",
                    Options = new List<string> { "A) Azure SQL Database", "B) Azure Database for PostgreSQL", "C) Azure Cosmos DB", "D) Azure Cache for Redis" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Cosmos DB", Difficulty = 2
                },
                new Question
                {
                    Id = 90,
                    Text = "In the shared responsibility model for cloud security, who is responsible for securing the physical infrastructure of datacenters (servers, network devices, buildings)?",
                    Options = new List<string> { "A) The customer", "B) Microsoft", "C) Shared responsibility based on the service type", "D) A third-party security provider" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Microsoft", Difficulty = 1
                },
                new Question
                {
                    Id = 91,
                    Text = "Which Azure tool provides detailed reports and compliance certifications (like ISO, SOC, GDPR) that customers can download to demonstrate Azure's compliance with industry standards?",
                    Options = new List<string> { "A) Azure Policy Compliance Dashboard", "B) Service Trust Portal", "C) Azure Security Center Regulatory Compliance", "D) Azure Monitor Workbooks" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Service Trust Portal", Difficulty = 2
                },
                new Question
                {
                    Id = 92,
                    Text = "You are deploying a web application that will have significant traffic spikes during marketing campaigns. Which Azure feature allows you to automatically increase the number of VM instances during peak times and reduce them during off-peak times?",
                    Options = new List<string> { "A) Availability Sets", "B) Virtual Machine Scale Sets with autoscaling", "C) Load Balancer", "D) Azure Traffic Manager" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Virtual Machine Scale Sets with autoscaling", Difficulty = 2
                },
                new Question
                {
                    Id = 93,
                    Text = "What is the primary difference between Azure DevOps Services and GitHub from Microsoft's perspective?",
                    Options = new List<string> { "A) Azure DevOps is for open-source only, GitHub is for enterprises only", "B) Azure DevOps is a comprehensive suite of development tools (CI/CD, boards, repos), while GitHub is primarily a code hosting platform with strong community features, now also offering CI/CD (Actions)", "C) GitHub cannot be integrated with Azure services", "D) Azure DevOps does not support Git repositories" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure DevOps is a comprehensive suite of development tools (CI/CD, boards, repos), while GitHub is primarily a code hosting platform with strong community features, now also offering CI/CD (Actions)", Difficulty = 3
                },
                new Question
                {
                    Id = 94,
                    Text = "Which Azure service is best suited for running batch processing jobs that require a large number of VMs for a short period, and you don't want to manage the cluster infrastructure?",
                    Options = new List<string> { "A) Azure Virtual Machines", "B) Azure Batch", "C) Azure Kubernetes Service (AKS)", "D) Azure Container Instances (ACI)" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Batch", Difficulty = 3
                },
                new Question
                {
                    Id = 95,
                    Text = "What does Azure Hybrid Benefit allow you to do?",
                    Options = new List<string> { "A) Get free Azure support", "B) Use your existing on-premises Windows Server and SQL Server licenses with Software Assurance to save money on Azure VMs and SQL Database", "C) Connect your on-premises network to Azure for free", "D) Migrate your data to Azure without cost" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Use your existing on-premises Windows Server and SQL Server licenses with Software Assurance to save money on Azure VMs and SQL Database", Difficulty = 2
                },
                new Question
                {
                    Id = 96,
                    Text = "Which Azure service provides real-time analytics on fast-moving streams of data from applications, devices, sensors, and more?",
                    Options = new List<string> { "A) Azure Data Factory", "B) Azure Stream Analytics", "C) Azure Data Lake Storage", "D) Azure Synapse Analytics" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Azure Stream Analytics", Difficulty = 2
                },
                new Question
                {
                    Id = 97,
                    Text = "When using Azure Policy, what does the 'Deny' effect do?",
                    Options = new List<string> { "A) It prevents non-compliant resources from being created", "B) It marks non-compliant resources for review", "C) It automatically corrects non-compliant resources", "D) It sends an alert when a non-compliant resource is created" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) It prevents non-compliant resources from being created", Difficulty = 2
                },
                new Question
                {
                    Id = 98,
                    Text = "Which of the following is NOT a valid way to interact with and manage Azure resources?",
                    Options = new List<string> { "A) Azure Portal (web interface)", "B) Azure CLI (command-line interface)", "C) Azure PowerShell", "D) Microsoft Office 365 Admin Center" },
                    CorrectAnswer = "D", CorrectAnswerText = "D) Microsoft Office 365 Admin Center", Difficulty = 1
                },
                new Question
                {
                    Id = 99,
                    Text = "What is the purpose of Azure Monitor Application Insights?",
                    Options = new List<string> { "A) To monitor the health of Azure datacenters", "B) To provide an application performance management (APM) service for live web applications, detecting issues and diagnosing crashes", "C) To manage user access to applications", "D) To back up application data" },
                    CorrectAnswer = "B", CorrectAnswerText = "B) To provide an application performance management (APM) service for live web applications, detecting issues and diagnosing crashes", Difficulty = 2
                },
                new Question
                {
                    Id = 100,
                    Text = "Which Azure networking service enables you to create a secure and private connection between Azure virtual networks or between an Azure VNet and an on-premises network over the Internet using encrypted tunnels?",
                    Options = new List<string> { "A) Azure ExpressRoute", "B) VNet Peering", "C) Azure VPN Gateway", "D) Azure Private Link" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure VPN Gateway", Difficulty = 2
                },

                // ==================== БЛОК 6 (Вопросы 101-120) — Целевые вопросы на слабые места ====================
                new Question
                {
                    Id = 101,
                    Text = "A retail company runs its point-of-sale and inventory management systems on servers located in its own corporate data center. To handle seasonal spikes in online shopping, they plan to use Azure Virtual Machines. This approach is an example of which cloud deployment model?",
                    Options = new List<string> { "A) Public cloud", "B) Private cloud", "C) Hybrid cloud", "D) Community cloud" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Hybrid cloud", Difficulty = 2
                },
                new Question
                {
                    Id = 102,
                    Text = "Which Azure service is specifically designed to run large-scale parallel and high-performance computing (HPC) batch jobs, automatically managing the creation, scaling, and deletion of a pool of compute nodes?",
                    Options = new List<string> { "A) Azure Virtual Machine Scale Sets", "B) Azure Kubernetes Service (AKS)", "C) Azure Batch", "D) Azure Container Instances (ACI)" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Batch", Difficulty = 3
                },
                new Question
                {
                    Id = 103,
                    Text = "You need to establish a dedicated, private network connection from your on-premises data center to Azure that does not travel over the public internet and offers the highest reliability and predictable bandwidth. Which Azure service should you use?",
                    Options = new List<string> { "A) Site-to-Site VPN (VPN Gateway)", "B) VNet Peering", "C) Azure ExpressRoute", "D) Azure Private Link" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure ExpressRoute", Difficulty = 2
                },
                new Question
                {
                    Id = 104,
                    Text = "A company's IT infrastructure consists entirely of physical servers and networking equipment purchased and maintained in their own building. This is most accurately described as:",
                    Options = new List<string> { "A) A public cloud using a CapEx model.", "B) A private cloud using an OpEx model.", "C) An on-premises datacenter using a CapEx model.", "D) A hybrid cloud using a mixed CapEx/OpEx model." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) An on-premises datacenter using a CapEx model.", Difficulty = 2
                },
                new Question
                {
                    Id = 105,
                    Text = "The Azure Hybrid Benefit can be applied to which of the following to reduce costs? (Select all that apply)",
                    Options = new List<string> { "A) Azure Virtual Machines running Windows Server", "B) Azure SQL Database", "C) Azure Virtual Machines running Linux", "D) Azure App Service" },
                    CorrectAnswer = "A, B", CorrectAnswerText = "A) Azure Virtual Machines running Windows Server and B) Azure SQL Database", Difficulty = 3
                },
                new Question
                {
                    Id = 106,
                    Text = "What is the primary networking benefit of using Global VNet Peering compared to a VPN Gateway connection between two Azure virtual networks in different regions?",
                    Options = new List<string> { "A) Global VNet Peering provides end-to-end encryption of the traffic.", "B) Global VNet Peering traffic travels over the Microsoft backbone network, offering lower latency and higher bandwidth without encryption overhead.", "C) Global VNet Peering is less expensive because it uses the public internet.", "D) Global VNet Peering requires a physical circuit from a connectivity provider." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Global VNet Peering traffic travels over the Microsoft backbone network, offering lower latency and higher bandwidth without encryption overhead.", Difficulty = 4
                },
                new Question
                {
                    Id = 107,
                    Text = "A startup is building a new mobile game that needs a database to store player profiles and scores. The game is expected to launch globally. They need a database that can automatically scale and replicate data to multiple regions with a single click to ensure low latency for players worldwide. Which Azure database service is the best fit?",
                    Options = new List<string> { "A) Azure SQL Database", "B) Azure Database for MySQL", "C) Azure Cosmos DB", "D) Azure Cache for Redis" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Cosmos DB", Difficulty = 2
                },
                new Question
                {
                    Id = 108,
                    Text = "In the shared responsibility model, which task is always the responsibility of the cloud provider (Microsoft), regardless of the service type (IaaS, PaaS, SaaS)?",
                    Options = new List<string> { "A) Encrypting customer data at rest.", "B) Managing physical security of datacenter facilities.", "C) Configuring network security groups (NSGs).", "D) Patching the guest operating system." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) Managing physical security of datacenter facilities.", Difficulty = 2
                },
                new Question
                {
                    Id = 109,
                    Text = "Which of the following is a key characteristic that distinguishes a public cloud from a private cloud?",
                    Options = new List<string> { "A) The public cloud uses virtualization, while a private cloud does not.", "B) The public cloud's resources are shared among multiple customers (multi-tenant), while a private cloud's resources are dedicated to a single organization.", "C) The public cloud is always more expensive than a private cloud.", "D) The public cloud can only be accessed over the internet, while a private cloud can only be accessed from a local network." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) The public cloud's resources are shared among multiple customers (multi-tenant), while a private cloud's resources are dedicated to a single organization.", Difficulty = 2
                },
                new Question
                {
                    Id = 110,
                    Text = "You are deploying a multi-tier application. You need to ensure the database tier is not accessible from the internet, but can be reached by the web servers. Both tiers are in the same Azure region. Which networking feature provides the simplest and most cost-effective way to connect them with low latency?",
                    Options = new List<string> { "A) Deploy each tier in a separate VNet and connect them using VPN Gateway.", "B) Deploy each tier in a separate VNet and connect them using VNet Peering.", "C) Deploy each tier in a separate subnet within the same VNet and use Network Security Groups (NSGs).", "D) Deploy the database on-premises and use ExpressRoute to connect the web servers in Azure." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Deploy each tier in a separate subnet within the same VNet and use Network Security Groups (NSGs).", Difficulty = 3
                },
                new Question
                {
                    Id = 111,
                    Text = "A company has existing licenses for Windows Server 2019 with active Software Assurance. They are migrating several on-premises servers to Azure Virtual Machines. What can they use to avoid paying for new Windows Server licenses in Azure and reduce their VM costs?",
                    Options = new List<string> { "A) Azure Cost Management", "B) Azure Reserved Virtual Machine Instances", "C) Azure Hybrid Benefit", "D) Azure Dev/Test Pricing" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Hybrid Benefit", Difficulty = 2
                },
                new Question
                {
                    Id = 112,
                    Text = "For a globally distributed application using Azure Cosmos DB, which feature allows you to add a new Azure region for data replication with minimal configuration and downtime?",
                    Options = new List<string> { "A) Geo-restore", "B) Manual failover", "C) Turnkey global distribution", "D) Multi-master writes" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Turnkey global distribution", Difficulty = 3
                },
                new Question
                {
                    Id = 113,
                    Text = "Which statement accurately describes a primary use case for Azure Batch?",
                    Options = new List<string> { "A) To host a continuously running web application with variable traffic.", "B) To orchestrate complex microservices composed of dozens of containers.", "C) To process a large number of financial risk simulations that require thousands of CPU cores for a few hours.", "D) To provide a serverless environment for running small pieces of event-driven code." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) To process a large number of financial risk simulations that require thousands of CPU cores for a few hours.", Difficulty = 3
                },
                new Question
                {
                    Id = 114,
                    Text = "What is a key advantage of using VNet Peering to connect two virtual networks in Azure over using a VPN Gateway connection?",
                    Options = new List<string> { "A) VNet Peering provides a more secure connection because it encrypts all traffic by default.", "B) VNet Peering offers higher bandwidth and lower latency because traffic flows through the Microsoft backbone network, not over the public internet.", "C) VNet Peering is a better solution for connecting an on-premises network to Azure.", "D) VNet Peering is always free of charge." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) VNet Peering offers higher bandwidth and lower latency because traffic flows through the Microsoft backbone network, not over the public internet.", Difficulty = 4
                },
                new Question
                {
                    Id = 115,
                    Text = "A company uses Azure for development and testing environments, which are only needed during business hours. Which licensing benefit can help them run these non-production workloads at a reduced cost?",
                    Options = new List<string> { "A) Azure Hybrid Benefit", "B) Azure Reservations", "C) Azure Dev/Test Pricing", "D) Pay-As-You-Go" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Azure Dev/Test Pricing", Difficulty = 3
                },
                new Question
                {
                    Id = 116,
                    Text = "Which Azure Cosmos DB feature ensures that your application can continue to read and write to the database even if a regional outage occurs, with minimal manual intervention?",
                    Options = new List<string> { "A) Analytical Store", "B) Automatic Indexing", "C) Multi-region writes (Multi-master)", "D) Time-to-Live (TTL)" },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Multi-region writes (Multi-master)", Difficulty = 4
                },
                new Question
                {
                    Id = 117,
                    Text = "When comparing ExpressRoute to a Site-to-Site VPN, which of the following is a true statement?",
                    Options = new List<string> { "A) ExpressRoute connections are easier and faster to set up than VPN connections.", "B) ExpressRoute provides a connection that is logically isolated from the public internet, while VPN traffic is encrypted and sent over the internet.", "C) ExpressRoute is generally less expensive than a VPN for the same amount of bandwidth.", "D) ExpressRoute does not require any hardware on the customer's premises." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) ExpressRoute provides a connection that is logically isolated from the public internet, while VPN traffic is encrypted and sent over the internet.", Difficulty = 3
                },
                new Question
                {
                    Id = 118,
                    Text = "A research institution needs to run a complex climate modeling simulation that will require over 10,000 CPU cores for approximately 48 hours once per month. They want to avoid managing a large on-premises cluster that would sit idle most of the time. Which Azure service is the best fit?",
                    Options = new List<string> { "A) Provision 10,000 Azure Virtual Machines manually each month.", "B) Use Azure Kubernetes Service (AKS) to orchestrate a large container cluster.", "C) Use Azure Batch to define the job and let it manage the compute pool.", "D) Use Azure Functions and run the simulation in parallel functions." },
                    CorrectAnswer = "C", CorrectAnswerText = "C) Use Azure Batch to define the job and let it manage the compute pool.", Difficulty = 4
                },
                new Question
                {
                    Id = 119,
                    Text = "In a hybrid cloud model, which Azure service is most commonly used to establish identity federation and enable single sign-on (SSO) between on-premises Active Directory and cloud applications?",
                    Options = new List<string> { "A) Azure Active Directory (Azure AD) with Azure AD Connect", "B) Azure AD Domain Services", "C) Network Security Groups (NSG)", "D) Azure ExpressRoute" },
                    CorrectAnswer = "A", CorrectAnswerText = "A) Azure Active Directory (Azure AD) with Azure AD Connect", Difficulty = 3
                },
                new Question
                {
                    Id = 120,
                    Text = "Which of the following best describes the economic advantage of moving from a capital expenditure (CapEx) model to an operational expenditure (OpEx) model with cloud computing?",
                    Options = new List<string> { "A) It requires a larger upfront investment but has lower long-term costs.", "B) It converts large upfront costs into smaller, predictable periodic payments, improving cash flow and reducing financial risk.", "C) It guarantees that the total cost of ownership (TCO) will be lower over five years.", "D) It eliminates all costs associated with IT infrastructure." },
                    CorrectAnswer = "B", CorrectAnswerText = "B) It converts large upfront costs into smaller, predictable periodic payments, improving cash flow and reducing financial risk.", Difficulty = 2
                }
            };
        }

        public static List<Question> GetAllQuestionsExtended()
        {
            var all = GetAllQuestions();
            all.AddRange(QuestionBank2.GetAdditionalQuestions());
            return all;
        }

        public static List<Question> GetQuestionsByDifficulty(int minDifficulty, int maxDifficulty)
        {
            return GetAllQuestions()
                .Where(q => q.Difficulty >= minDifficulty && q.Difficulty <= maxDifficulty)
                .ToList();
        }

        public static List<Question> GetQuestionsByIdRange(int startId, int endId)
        {
            return GetAllQuestions()
                .Where(q => q.Id >= startId && q.Id <= endId)
                .ToList();
        }

        public static Dictionary<int, int> GetDifficultyStatistics()
        {
            var allQuestions = GetAllQuestions();
            var stats = new Dictionary<int, int>();
            for (int i = 1; i <= 5; i++)
                stats[i] = allQuestions.Count(q => q.Difficulty == i);
            return stats;
        }
    }
}
