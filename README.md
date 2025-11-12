# 🎬 GitHub Copilot Workshop

Welcome to the **GitHub Copilot Workshop**! This hands-on project guides you through building a stylish, production-ready movie management application using the latest tools and best practices. Learn how to leverage GitHub Copilot to accelerate your development workflow while building a full-stack application.

## 📋 Project Overview

This workshop demonstrates building a complete movie management system with:
- **Backend:** ASP.NET Core 9.0 Web API for managing movies and categories
- **Frontend:** Vue 3 + Vite for a modern, responsive user interface
- **MCP Server:** Model Context Protocol integration for advanced agent features
- **GitHub Copilot:** Extensive use of AI-assisted development throughout

## ✨ Key Features

- 🎥 Movie and category management system
- 🗂️ Entity Framework Core with in-memory database
- 🎨 Modern Vue 3 UI with Tailwind CSS
- 🧪 NUnit-based backend testing
- 🔌 RESTful API endpoints
- 🤖 MCP server integration for external data sources
- 🛠️ GitHub Copilot customizations and agents
- 📝 Custom prompts and instructions for enhanced AI assistance

## 🚀 Technology Stack

### Backend
- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API development
- **Entity Framework Core** - ORM for database operations
- **NUnit** - Unit testing framework
- **Bogus** - Fake data generation for testing

### Frontend
- **Vue 3** (v3.5.22) - Progressive JavaScript framework
- **Vite** (v7.1.11) - Next-generation frontend tooling
- **Tailwind CSS** - Utility-first CSS framework
- **Heroicons** - Beautiful hand-crafted SVG icons

### Tools & Extensions
- **GitHub Copilot** - AI pair programmer
- **Model Context Protocol (MCP)** - Agent customizations
- **VS Code** - Primary development environment

## 📋 Prerequisites

Before starting the workshop, ensure you have the following installed:

- **GitHub account** with access to GitHub Copilot
- **[.NET SDK 9.0 or later](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)**
- **[Node.js (v20.19.0+) and npm](https://nodejs.org/en/download/)**
- **[Git](https://git-scm.com/downloads)**
- **[Visual Studio Code](https://code.visualstudio.com/)**
- **[GitHub Copilot extension for VS Code](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot)**

## 🏗️ Project Architecture

The application follows a clean, separated architecture:

```
gh-workshop/
├── backend/              # ASP.NET Core Web API
│   ├── Models/          # Data models (Movie, Category, MovieUser)
│   ├── Data/            # DbContext and database configuration
│   ├── Properties/      # Application properties
│   └── Program.cs       # Application entry point & API endpoints
├── frontend/            # Vue 3 application
│   ├── src/            # Source code
│   │   ├── components/ # Vue components (MovieList, SeedMovies)
│   │   └── App.vue     # Root component
│   └── public/         # Static assets
├── instructions/        # Step-by-step workshop guides
├── starters/           # Starter files and templates
│   ├── files/          # Template files
│   └── mcp/            # MCP server starter code
└── .github/            # GitHub configurations
    ├── agents/         # Custom Copilot agents
    ├── prompts/        # Custom Copilot prompts
    └── instructions/   # Copilot instruction files
```

## 🎯 Getting Started

### Option 1: Clone the Repository

```bash
git clone <repository-url>
cd gh-workshop
```

### Option 2: Create Projects from Scratch

**Backend:**
```bash
dotnet new webapi -n backend --framework net9.0
```

**Frontend:**
```bash
npm create vue
# Name: frontend
# Select: "Skip all example code and start with a blank project" = Yes
```

### Running the Application

**Backend:**
```bash
cd backend
dotnet restore
dotnet build
dotnet run
```
Access at: `http://localhost:5065` (or port specified in console)

**Frontend:**
```bash
cd frontend
npm install
npm run dev
```
Access at: `http://localhost:5173`

## 📚 Workshop Structure

This workshop consists of progressive, hands-on lessons. Follow them in order for the best learning experience:

1. **[Project Introduction](instructions/0-project-explanation.md)** - Overview and setup
2. **[Clean Boilerplate](instructions/1-clean-boilerplate.md)** - Remove default code with Copilot
3. **[Add Backend Code](instructions/2-add-code-for-backend.md)** - Create models with AI assistance
4. **[Database Context](instructions/3-add-db-context.md)** - Set up Entity Framework Core
5. **[Backend Tests](instructions/4-backend-tests.md)** - Write unit tests with NUnit
6. **[Frontend Development](instructions/5-frontend.md)** - Build Vue 3 UI components
7. **[Connect Frontend & Backend](instructions/6-connecting-frontend-backend.md)** - Wire up the API
8. **[MCP Server](instructions/7-mcp-server.md)** - Integrate Model Context Protocol
9. **[Customizations](instructions/8-customizations.md)** - Add Copilot instructions
10. **[Debug Copilot](instructions/9-debug-copilot.md)** - Troubleshoot and optimize
11. **[Custom Agent](instructions/11-custom-agent.md)** - Create custom Copilot agents
12. **[Review Agent](instructions/12-review-agent.md)** - Code review automation
13. **[Additional Workshops](instructions/10-additional-workshops.md)** - Extended learning
14. **[Codespaces](instructions/13-spaces.md)** - Cloud development environment

## 🎓 What You'll Learn

- ✅ Scaffold and connect backend & frontend applications
- ✅ Use GitHub Copilot in **agent**, **edit**, and **ask** modes
- ✅ Create data models with Entity Framework Core
- ✅ Write and run automated tests
- ✅ Build modern UI components with Vue 3 and Tailwind CSS
- ✅ Connect frontend to backend RESTful APIs
- ✅ Configure CORS for cross-origin requests
- ✅ Use GitHub Copilot customizations and prompts
- ✅ Integrate MCP servers for advanced features
- ✅ Debug and optimize Copilot interactions
- ✅ Create custom Copilot agents for specialized tasks

## 🧪 Testing

The project includes comprehensive backend testing:

```bash
cd backend.Tests
dotnet test
```

Tests cover:
- API endpoint functionality
- Database seeding operations
- Data retrieval and serialization
- Entity Framework Core operations

## 🤝 Development Workflow

### Using GitHub Copilot

This workshop emphasizes using GitHub Copilot throughout the development process:

- **Agent Mode**: For complex, multi-step tasks and code generation
- **Edit Mode**: For focused code modifications
- **Ask Mode**: For explanations and guidance

### Recommended Practices

- Use Copilot Chat to run commands and interact with the project
- Leverage custom prompts for consistent code patterns
- Create instruction files for domain-specific guidance
- Use MCP servers for external integrations
- Debug with Copilot's assistance using chat history exports

## 🎨 Coding Standards

- Follow .NET naming conventions and coding standards
- Use data annotations for model validation
- Implement navigation properties for entity relationships
- Add inline checklists in code comments for complex implementations
- Use async/await for asynchronous operations
- Leverage dependency injection for service management

## 🔌 MCP Server Integration

The workshop includes integration with a Model Context Protocol (MCP) server for advanced features:

- External movie data sources
- Custom tool implementations
- Enhanced Copilot capabilities
- Workspace-specific configurations

Located at `.vscode/mcp-servers.json`

## 🛠️ Customizations

The project uses GitHub Copilot customizations for enhanced AI assistance:

- **Custom Prompts**: Reusable prompts in `.github/prompts/`
- **Instructions**: Domain-specific guidance in `.github/instructions/`
- **Custom Agents**: Specialized agents in `.github/agents/`
- **Awesome Copilot**: Curated collections from the community

## 🐛 Troubleshooting

If you encounter issues:

1. **Ensure all prerequisites are installed** (check versions)
2. **Verify internet connection** for Copilot features
3. **Check GitHub Copilot extension** is activated
4. **Review Output logs** (View > Output > GitHub Copilot)
5. **Consult the Debug Copilot guide** in the instructions
6. **Visit [GitHub Status](https://www.githubstatus.com/)** for service status

## 🤝 Contributing

This is a workshop project designed for learning. Feel free to:

- Extend the functionality with additional features
- Add more comprehensive tests
- Improve the UI/UX design
- Create additional workshop modules
- Share your customizations and agents

## 📖 Additional Resources

- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [Awesome Copilot](https://github.com/github/awesome-copilot)
- [Model Context Protocol](https://github.com/modelcontextprotocol)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Vue 3 Documentation](https://vuejs.org/)
- [Tailwind CSS Documentation](https://tailwindcss.com/)

## 📝 License

This project is for educational purposes. Check with your organization regarding licensing for production use.

---

## 🚀 Ready to Start?

Begin your journey with the [workshop introduction](instructions/0-project-explanation.md)!

<div align="center">
  <a href="instructions/0-project-explanation.md">
    <img src="instructions/images/general/start-arrow.png" alt="Start with workshop" width="128" height="128" />
  </a>
</div>

---

**Happy Coding with GitHub Copilot! 🎉**
