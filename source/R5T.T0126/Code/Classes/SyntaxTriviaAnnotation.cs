using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxTriviaAnnotation : TypedSyntaxAnnotation<SyntaxTrivia>
    {
        #region Static

        public static SyntaxTriviaAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new SyntaxTriviaAnnotation(annotation);
            return output;
        }

        #endregion


        public SyntaxTriviaAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
