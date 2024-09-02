.NET Application with Docker Compose, Redis, and PostgreSQL

This repository demonstrates the setup of a .NET application using Docker Compose, integrating Redis for caching and PostgreSQL for data management. This setup aims to enhance application performance and simplify database operations using containerization.
📋 Project Overview

This project includes:

    Redis for caching to optimize application performance.
    PostgreSQL as the primary database to handle data persistence.
    Docker Compose to orchestrate and manage the containers, allowing easy setup and scalability.

🛠️ Services in the Docker Compose File

    Redis Cache (speedupapi_redis):
        Image: Custom-built from SpeedUpAPI_Redis/Dockerfile.
        Purpose: Provides high-speed caching to reduce load times and improve response rates.
        Ports: 5000, 5001.

    PostgreSQL Database (products.database):
        Image: postgres:latest.
        Environment Variables:
            POSTGRES_DB=products
            POSTGRES_USER=postgres
            POSTGRES_PASSWORD=postgres
        Volume Mount: ./.containers/product-db:/var/lib/postgresql/data to ensure persistent data storage.
        Ports: 5432.

    Standalone Redis Instance (product.redis):
        Image: redis:latest.
        Purpose: Used as an additional caching layer.
        Restart Policy: Always restarts to maintain availability.
        Ports: 6379.

🚀 Getting Started

Follow these steps to set up and run the application:

    Clone the Repository:

    bash

git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name

Build and Start the Containers:

bash

    docker-compose up --build

    Access the Services:
        API Service: Available at http://localhost:5000
        PostgreSQL Database: Accessible via localhost:5432 using the credentials defined in the environment variables.
        Redis Cache: Accessible at localhost:6379.

📂 Directory Structure

graphql

├── SpeedUpAPI_Redis/
│   ├── Dockerfile          # Dockerfile for Redis API container
├── .containers/
│   ├── product-db/         # Volume for PostgreSQL data persistence
├── docker-compose.yml      # Main Docker Compose configuration

📝 Configuration Details

    Redis Configuration: Both Redis services are set up to handle caching, improving the data retrieval times for your application.
    PostgreSQL Configuration: Configured to store application data with persistence enabled through Docker volumes.

📊 Data Persistence

    PostgreSQL Data: Stored within ./.containers/product-db, ensuring data remains intact even if the container is restarted.

🤝 Contributing

We welcome contributions! Feel free to fork the repository, open issues, or submit pull requests to suggest improvements or report bugs.
📄 License

This project is licensed under the MIT License - see the LICENSE.md file for more details.
📧 Contact

For any questions or further information, you can reach me at tayyab.bhatti30@gmail.com.