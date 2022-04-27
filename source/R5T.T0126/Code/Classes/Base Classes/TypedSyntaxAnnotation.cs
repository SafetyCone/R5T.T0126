using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public abstract class TypedSyntaxAnnotation
    {
        #region Static

        public static implicit operator SyntaxAnnotation(TypedSyntaxAnnotation typedAnnotation)
        {
            return typedAnnotation.SyntaxAnnotation;
        }

        #endregion


        public SyntaxAnnotation SyntaxAnnotation { get; }


        protected TypedSyntaxAnnotation(SyntaxAnnotation annotation)
        {
            this.SyntaxAnnotation = annotation;
        }
    }


    /// <summary>
    /// Allows a <see cref="Microsoft.CodeAnalysis.SyntaxAnnotation"/> to be strongly-typed with the syntax type it annotates.
    /// </summary>
    /// <typeparam name="TSyntax">Dummy type, for now. But it's intended to only be <see cref="SyntaxNode"/>, <see cref="SyntaxToken"/>, and <see cref="SyntaxTrivia"/> in a dervived type for each type.</typeparam>
    public abstract class TypedSyntaxAnnotation<TSyntax> : TypedSyntaxAnnotation
    {
        protected TypedSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
