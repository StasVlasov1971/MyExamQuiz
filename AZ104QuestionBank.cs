using System.Collections.Generic;

namespace AzureExamQuestions
{
    public static class AZ104QuestionBank
    {
        public static List<Question> GetAllQuestions() => new()
        {
            // ── Домен 1: Identity & Governance ──────────────────────────────

            new Question
            {
                Id = 1,
                Text = "An administrator needs to grant a user the ability to create and manage virtual machines, but must NOT allow them to manage virtual networks or assign permissions to others. Which built-in RBAC role is most appropriate?",
                Options = new List<string>
                {
                    "A) Contributor",
                    "B) Virtual Machine Contributor",
                    "C) Owner",
                    "D) Network Contributor"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Virtual Machine Contributor",
                Difficulty = 2
            },
            new Question
            {
                Id = 2,
                Text = "You need to move several Azure resources (VMs, storage accounts) from Subscription A to Subscription B within the same Azure AD tenant. Which statement is TRUE about this operation?",
                Options = new List<string>
                {
                    "A) Resources cannot be moved between subscriptions.",
                    "B) Most resource types can be moved; the resources are temporarily unavailable during the move.",
                    "C) Moving resources changes their resource IDs, which may break existing references.",
                    "D) B and C are both correct."
                },
                CorrectAnswer = "D", CorrectAnswerText = "D) B and C are both correct.",
                Difficulty = 3
            },
            new Question
            {
                Id = 3,
                Text = "An administrator needs to temporarily grant a vendor elevated Azure access for 48 hours to perform maintenance. The access must expire automatically. Which Azure AD feature should be used?",
                Options = new List<string>
                {
                    "A) Permanent RBAC role assignment at the subscription scope",
                    "B) Azure AD Privileged Identity Management (PIM) with a time-bounded eligible assignment",
                    "C) Azure Policy with a time-based condition",
                    "D) Azure Conditional Access policy"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure AD Privileged Identity Management (PIM) with a time-bounded eligible assignment",
                Difficulty = 3
            },
            new Question
            {
                Id = 4,
                Text = "Which Azure feature allows you to enforce that all resources in a subscription must have a specific tag (e.g., 'Environment'), and automatically add the tag to non-compliant resources that are missing it?",
                Options = new List<string>
                {
                    "A) Azure RBAC with a custom role",
                    "B) Azure Resource Locks",
                    "C) Azure Policy with the 'Modify' effect",
                    "D) Azure Blueprints with a tag artifact"
                },
                CorrectAnswer = "C", CorrectAnswerText = "C) Azure Policy with the 'Modify' effect",
                Difficulty = 3
            },
            new Question
            {
                Id = 5,
                Text = "An organization wants to delegate password reset permissions to a helpdesk team for regular (non-admin) users only, without granting Global Administrator rights. Which Azure AD role is most appropriate?",
                Options = new List<string>
                {
                    "A) Security Administrator",
                    "B) User Administrator",
                    "C) Helpdesk Administrator",
                    "D) Authentication Administrator"
                },
                CorrectAnswer = "C", CorrectAnswerText = "C) Helpdesk Administrator",
                Difficulty = 3
            },
            new Question
            {
                Id = 6,
                Text = "You need to audit all control-plane operations (create, update, delete) performed on Azure resources in your subscription over the last 90 days. Which Azure service stores this information?",
                Options = new List<string>
                {
                    "A) Azure Monitor Metrics",
                    "B) Azure Activity Log",
                    "C) Azure Resource Graph",
                    "D) Azure Advisor"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Activity Log",
                Difficulty = 2
            },

            // ── Домен 2: Storage ─────────────────────────────────────────────

            new Question
            {
                Id = 7,
                Text = "Which Azure Storage redundancy option replicates data synchronously across three availability zones within the primary region, providing the highest durability within a single region?",
                Options = new List<string>
                {
                    "A) LRS — Locally Redundant Storage",
                    "B) ZRS — Zone-Redundant Storage",
                    "C) GRS — Geo-Redundant Storage",
                    "D) GZRS — Geo-Zone-Redundant Storage"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) ZRS — Zone-Redundant Storage",
                Difficulty = 2
            },
            new Question
            {
                Id = 8,
                Text = "You need to automatically move Azure Blob data to the Cool tier after 30 days and delete it after 365 days of no modification. What should you configure?",
                Options = new List<string>
                {
                    "A) Azure Backup retention policy",
                    "B) Blob Storage lifecycle management policy",
                    "C) Azure Policy with a storage rule",
                    "D) Blob versioning with soft delete"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Blob Storage lifecycle management policy",
                Difficulty = 2
            },
            new Question
            {
                Id = 9,
                Text = "Which Azure Blob Storage access tier has the LOWEST storage cost per GB but requires a minimum storage duration of 180 days and has the highest retrieval cost?",
                Options = new List<string>
                {
                    "A) Hot tier",
                    "B) Cool tier",
                    "C) Cold tier",
                    "D) Archive tier"
                },
                CorrectAnswer = "D", CorrectAnswerText = "D) Archive tier",
                Difficulty = 2
            },
            new Question
            {
                Id = 10,
                Text = "Multiple Azure virtual machines need to share a common file system simultaneously using the SMB protocol. Which Azure storage service provides this capability?",
                Options = new List<string>
                {
                    "A) Azure Blob Storage (NFS mount)",
                    "B) Azure Files",
                    "C) Azure Managed Disks",
                    "D) Azure Queue Storage"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Files",
                Difficulty = 2
            },
            new Question
            {
                Id = 11,
                Text = "You generate a Shared Access Signature (SAS) token for an Azure Storage blob. The token expires in 24 hours. Before it expires, you discover the token was accidentally exposed. What is the FASTEST way to revoke it?",
                Options = new List<string>
                {
                    "A) Delete the storage account and recreate it.",
                    "B) Rotate the storage account access key used to sign the SAS token.",
                    "C) Change the storage account replication option.",
                    "D) Disable public access on the container."
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Rotate the storage account access key used to sign the SAS token.",
                Difficulty = 3
            },

            // ── Домен 3: Compute ─────────────────────────────────────────────

            new Question
            {
                Id = 12,
                Text = "Which Azure VM disk type provides the highest IOPS and throughput with sub-millisecond latency, designed for IO-intensive workloads like SAP HANA and top-tier databases?",
                Options = new List<string>
                {
                    "A) Standard HDD",
                    "B) Standard SSD",
                    "C) Premium SSD v2",
                    "D) Ultra Disk"
                },
                CorrectAnswer = "D", CorrectAnswerText = "D) Ultra Disk",
                Difficulty = 2
            },
            new Question
            {
                Id = 13,
                Text = "An Azure VM's OS disk is running out of space. The VM is currently running in production with a supported OS. What is the RECOMMENDED approach to expand the disk with minimal disruption?",
                Options = new List<string>
                {
                    "A) Deallocate the VM, resize the disk, start the VM, then extend the partition inside the OS.",
                    "B) Use online disk resize (no deallocation required for supported VM sizes) then extend the partition inside the OS.",
                    "C) Attach a new data disk and migrate the OS partition manually.",
                    "D) Create a snapshot, restore to a new, larger VM."
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Use online disk resize (no deallocation required for supported VM sizes) then extend the partition inside the OS.",
                Difficulty = 3
            },
            new Question
            {
                Id = 14,
                Text = "You need to automatically shut down development VMs every day at 7 PM (with no auto-start). The SIMPLEST way to configure this per-VM with no custom scripting is:",
                Options = new List<string>
                {
                    "A) Azure Automation runbook with a schedule",
                    "B) Auto-shutdown feature built into each VM's settings in the portal",
                    "C) Azure Logic App triggered by a timer",
                    "D) Azure DevTest Labs policy"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Auto-shutdown feature built into each VM's settings in the portal",
                Difficulty = 1
            },
            new Question
            {
                Id = 15,
                Text = "You need to protect Azure VMs so that deleted or corrupted data can be restored to any point within the last 14 days. Which service provides VM-level backup and point-in-time restore?",
                Options = new List<string>
                {
                    "A) Azure Site Recovery",
                    "B) Azure Backup with a Recovery Services Vault",
                    "C) Azure Managed Disk snapshots only",
                    "D) Azure Archive Storage"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Backup with a Recovery Services Vault",
                Difficulty = 2
            },
            new Question
            {
                Id = 16,
                Text = "A web application runs on five Azure VMs behind a load balancer. During deployments, you need to ensure at least 3 VMs remain available. The VMs must be protected from both planned maintenance and unplanned hardware failures in the SAME datacenter. Which feature should you use?",
                Options = new List<string>
                {
                    "A) Availability Zones across three regions",
                    "B) Availability Set with fault domains and update domains",
                    "C) Virtual Machine Scale Sets with default settings",
                    "D) Azure Site Recovery"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Availability Set with fault domains and update domains",
                Difficulty = 3
            },
            new Question
            {
                Id = 17,
                Text = "Which Azure Compute service is best suited for running large-scale parallel batch jobs (e.g., rendering 10,000 video frames) that require hundreds of VMs for a few hours without managing the cluster infrastructure?",
                Options = new List<string>
                {
                    "A) Azure Virtual Machine Scale Sets",
                    "B) Azure Kubernetes Service (AKS)",
                    "C) Azure Batch",
                    "D) Azure Container Instances"
                },
                CorrectAnswer = "C", CorrectAnswerText = "C) Azure Batch",
                Difficulty = 2
            },
            new Question
            {
                Id = 18,
                Text = "An Azure App Service web app is experiencing slow response times. The CPU metric consistently exceeds 80% during business hours. You need to automatically add instances during peak load and reduce them at night. What should you configure?",
                Options = new List<string>
                {
                    "A) Change the App Service Plan to a higher SKU manually each morning",
                    "B) Enable Autoscale on the App Service Plan with CPU-based scale-out rules",
                    "C) Deploy to Azure Functions instead",
                    "D) Add a CDN in front of the app"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Enable Autoscale on the App Service Plan with CPU-based scale-out rules",
                Difficulty = 2
            },

            // ── Домен 4: Networking ──────────────────────────────────────────

            new Question
            {
                Id = 19,
                Text = "You need to allow only specific IP addresses to access an Azure VM using RDP (port 3389) and block all other inbound internet traffic. The SIMPLEST configuration is to:",
                Options = new List<string>
                {
                    "A) Configure an Azure Firewall rule",
                    "B) Add an inbound NSG rule allowing RDP from specific IPs, and ensure the default Deny rule blocks everything else",
                    "C) Use Azure DDoS Protection Standard",
                    "D) Enable Azure Bastion on the VNet"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Add an inbound NSG rule allowing RDP from specific IPs, and ensure the default Deny rule blocks everything else",
                Difficulty = 2
            },
            new Question
            {
                Id = 20,
                Text = "You need to route ALL internet-bound traffic from a VNet through a Network Virtual Appliance (NVA) for inspection, overriding the default Azure routing. What must you configure?",
                Options = new List<string>
                {
                    "A) A Network Security Group with a block rule",
                    "B) User-Defined Routes (UDR) with a route table attached to the subnet",
                    "C) VNet Peering with gateway transit",
                    "D) Azure Firewall Policy"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) User-Defined Routes (UDR) with a route table attached to the subnet",
                Difficulty = 3
            },
            new Question
            {
                Id = 21,
                Text = "Two VNets (VNet-A in East US, VNet-B in West Europe) need to communicate. The connection must use the Microsoft backbone network (not the public internet) and must NOT require a gateway. Which solution should you choose?",
                Options = new List<string>
                {
                    "A) Site-to-Site VPN between the two VNets",
                    "B) Global VNet Peering",
                    "C) Azure ExpressRoute with Global Reach",
                    "D) Azure Virtual WAN hub"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Global VNet Peering",
                Difficulty = 2
            },
            new Question
            {
                Id = 22,
                Text = "You need to allow VMs in a VNet to access Azure Storage over the Microsoft backbone network without assigning a public IP to the storage account. Which networking feature achieves this?",
                Options = new List<string>
                {
                    "A) Service Endpoints — routes traffic to the public endpoint over the backbone",
                    "B) Private Endpoint — assigns a private IP from the VNet to the storage account",
                    "C) VNet Peering to Microsoft's backbone",
                    "D) Azure ExpressRoute"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Private Endpoint — assigns a private IP from the VNet to the storage account",
                Difficulty = 3
            },
            new Question
            {
                Id = 23,
                Text = "Which Azure load-balancing service operates at OSI Layer 4 (TCP/UDP), distributes traffic within a region, and supports health probes but does NOT inspect HTTP content or URL paths?",
                Options = new List<string>
                {
                    "A) Azure Application Gateway",
                    "B) Azure Front Door",
                    "C) Azure Load Balancer (Standard)",
                    "D) Azure Traffic Manager"
                },
                CorrectAnswer = "C", CorrectAnswerText = "C) Azure Load Balancer (Standard)",
                Difficulty = 2
            },
            new Question
            {
                Id = 24,
                Text = "An on-premises network must connect to Azure with a dedicated, private circuit (not over the public internet) providing up to 10 Gbps of consistent bandwidth for a mission-critical ERP system. Which Azure service should you use?",
                Options = new List<string>
                {
                    "A) Azure VPN Gateway (Site-to-Site)",
                    "B) Azure ExpressRoute",
                    "C) Global VNet Peering",
                    "D) Azure Virtual WAN"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure ExpressRoute",
                Difficulty = 2
            },
            new Question
            {
                Id = 25,
                Text = "You want to allow remote administrators to connect to Azure VMs securely using RDP/SSH through the Azure portal, without exposing port 3389 or 22 on a public IP. Which Azure service provides this?",
                Options = new List<string>
                {
                    "A) Azure VPN Point-to-Site",
                    "B) Azure Bastion",
                    "C) Azure Firewall with DNAT rules",
                    "D) Just-in-Time (JIT) VM access in Microsoft Defender for Cloud"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Bastion",
                Difficulty = 2
            },
            new Question
            {
                Id = 26,
                Text = "Which Azure DNS feature allows you to resolve Azure private endpoint hostnames (e.g., mystorageaccount.privatelink.blob.core.windows.net) from within a VNet?",
                Options = new List<string>
                {
                    "A) Azure Public DNS zone",
                    "B) Azure Private DNS zone linked to the VNet",
                    "C) Custom DNS server on the VNet",
                    "D) Azure Traffic Manager profile"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Private DNS zone linked to the VNet",
                Difficulty = 3
            },

            // ── Домен 5: Monitoring & Backup ─────────────────────────────────

            new Question
            {
                Id = 27,
                Text = "An administrator needs to write complex queries to correlate log data from multiple Azure resources (VMs, App Services, SQL Databases) and visualize trends over time. Which Azure Monitor feature enables this?",
                Options = new List<string>
                {
                    "A) Azure Monitor Metrics explorer",
                    "B) Log Analytics workspace with KQL (Kusto Query Language)",
                    "C) Azure Monitor Alerts",
                    "D) Azure Service Health"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Log Analytics workspace with KQL (Kusto Query Language)",
                Difficulty = 2
            },
            new Question
            {
                Id = 28,
                Text = "You need to be notified via email when a VM's average CPU utilization exceeds 90% for more than 5 minutes. What should you configure in Azure Monitor?",
                Options = new List<string>
                {
                    "A) A Diagnostic Setting",
                    "B) A Metric Alert rule with an Action Group containing an email action",
                    "C) An Azure Advisor recommendation",
                    "D) A Log Analytics query scheduled every 5 minutes"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) A Metric Alert rule with an Action Group containing an email action",
                Difficulty = 2
            },
            new Question
            {
                Id = 29,
                Text = "You need to replicate Azure VMs to a secondary Azure region so that in the event of a regional disaster, you can fail over the workload with a recovery time of less than 1 hour. Which Azure service provides this?",
                Options = new List<string>
                {
                    "A) Azure Backup with geo-redundant storage",
                    "B) Azure Site Recovery (ASR)",
                    "C) Cross-region restore in Azure Backup",
                    "D) Availability Zones"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Azure Site Recovery (ASR)",
                Difficulty = 2
            },
            new Question
            {
                Id = 30,
                Text = "Which Azure tool gives you a consolidated view of your Azure environment's health — including security vulnerabilities, compliance with policies, and actionable recommendations — across multiple subscriptions?",
                Options = new List<string>
                {
                    "A) Azure Advisor",
                    "B) Microsoft Defender for Cloud",
                    "C) Azure Monitor Workbooks",
                    "D) Azure Service Health"
                },
                CorrectAnswer = "B", CorrectAnswerText = "B) Microsoft Defender for Cloud",
                Difficulty = 2
            }
        };
    }
}
