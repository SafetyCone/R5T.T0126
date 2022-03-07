using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    /// <summary>
    /// Allows a <see cref="Microsoft.CodeAnalysis.SyntaxAnnotation"/> to be strongly-typed with the syntax type it annotates.
    /// </summary>
    /// <typeparam name="TSyntax">Dummy type, for now. Will be restricted later on.</typeparam>
    public abstract class TypedSyntaxAnnotation<TSyntax>
    {
        #region Static

        public static implicit operator SyntaxAnnotation(TypedSyntaxAnnotation<TSyntax> stronglyTypedAnnotation)
        {
            return stronglyTypedAnnotation.SyntaxAnnotation;
        }

        #endregion


        public SyntaxAnnotation SyntaxAnnotation { get; }


        protected TypedSyntaxAnnotation(SyntaxAnnotation annotation)
        {
            this.SyntaxAnnotation = annotation;
        }
    }
}
