# Enterprise Carpool: Multi-Tenant B2B Platform

![Build Status](https://img.shields.io/badge/build-passing-brightgreen) ![Version](https://img.shields.io/badge/version-1.0.0-orange)

## 📖 Overview

**Enterprise Carpool** is a B2B2C SaaS application designed to facilitate secure, verified carpooling within organizations. Unlike public carpooling services, this platform operates on a **Multi-Tenant Architecture**, ensuring that employees of a specific company ("Tenant") can only view and book rides with colleagues from the same organization.

This solution helps companies reduce their carbon footprint, alleviate parking congestion, and foster employee bonding, all while maintaining strict data isolation and security.

## 🚀 Key Features

### For Organizations (The Tenants)
* **Multi-Tenancy:** Strict data isolation. *Company A* data is invisible to *Company B*.
* **SSO Integration:** Supports SAML/OIDC (Google Workspace, Microsoft Entra ID) for seamless employee onboarding.
* **ESG Dashboard:** Analytics on CO2 emissions saved and total miles carpooled for corporate sustainability reporting.
* **White Labeling:** Custom branding (Logo, Color Scheme) for each tenant.

### For Employees (The End Users)
* **Verified Matching:** Ride only with verified coworkers.
* **Smart Routing:** Real-time route matching algorithms.
* **Gamification:** Leaderboards and badges for eco-friendly commuters.
* **Recurring Rides:** Schedule daily commute pickups easily.

---

## 🛠 Tech Stack

* **Frontend:** [React]
* **Backend:** [ASP.NET, .NET10]
* **Database:** [MSSQL]
* **Caching:** Redis (for session management and geospatial caching)
* **Infrastructure:** Docker, Kubernetes (K8s)

---
