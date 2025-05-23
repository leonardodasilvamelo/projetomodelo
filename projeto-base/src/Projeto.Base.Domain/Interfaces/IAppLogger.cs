using System;

namespace Projeto.Base.Domain.Interfaces
{
    /// <summary>
    /// Interface para serviço de logging da aplicação
    /// </summary>
    /// <typeparam name="T">Tipo da classe que está utilizando o logger</typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// Registra uma mensagem de informação
        /// </summary>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Registra uma mensagem de aviso
        /// </summary>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Registra uma mensagem de erro
        /// </summary>
        void LogError(Exception ex, string message, params object[] args);

        /// <summary>
        /// Registra uma mensagem de depuração
        /// </summary>
        void LogDebug(string message, params object[] args);
    }
} 
