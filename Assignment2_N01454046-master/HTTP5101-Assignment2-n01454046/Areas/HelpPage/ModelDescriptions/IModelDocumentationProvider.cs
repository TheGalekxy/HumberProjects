using System;
using System.Reflection;

namespace HTTP5101_Assignment2_n01454046.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}