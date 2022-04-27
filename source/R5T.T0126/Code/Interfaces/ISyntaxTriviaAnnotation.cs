using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public interface ISyntaxTriviaAnnotation
    {
        public SyntaxAnnotation SyntaxAnnotation { get; }
    }
}
