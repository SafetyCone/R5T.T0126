using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public static partial class CompilationUnitSyntaxExtensions
    {
        // Note: No Annotate() for the compilation unit, since the compilation unit is the compilation unit and is assumed will never need to be found.

        public static CompilationUnitSyntax AnnotateNode_Typed<TNode>(this CompilationUnitSyntax compilationUnit,
            TNode node,
            out SyntaxNodeSyntaxAnnotation<TNode> annotation,
            out TNode annotatedNode)
            where TNode : SyntaxNode
        {
            annotatedNode = node.Annotate_Typed(out annotation);

            var outputCompilationUnit = compilationUnit.ReplaceNode_Better(
                node,
                annotatedNode);

            return outputCompilationUnit;
        }

        public static CompilationUnitSyntax AnnotateNodes_Typed<TNode, TTypedSyntaxAnnotation>(this CompilationUnitSyntax compilationUnit,
            IEnumerable<TNode> descendantNodes,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor,
            out Dictionary<TNode, TTypedSyntaxAnnotation> annotationsByInputNode)
            where TNode : SyntaxNode
            where TTypedSyntaxAnnotation : SyntaxNodeSyntaxAnnotation<TNode>
        {
            var outputNode = compilationUnit.AnnotateNodes(
                descendantNodes,
                out var untypedAnnotationsByInputNode);

            annotationsByInputNode = untypedAnnotationsByInputNode.ToTypedAnnotationsByNode(
                typedSyntaxAnnotationConstructor);

            return outputNode;
        }

        public static TOut Get<TNode, TOut>(this CompilationUnitSyntax compilationUnit,
            SyntaxNodeSyntaxAnnotation<TNode> annotation,
            Func<TNode, TOut> selector)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var output = selector(node);
            return output;
        }

        public static TNode GetAnnotatedNode_Typed<TNode>(this CompilationUnitSyntax compilationUnit,
            SyntaxNodeSyntaxAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode(annotation.SyntaxAnnotation) as TNode;
            return node;
        }

        public static async Task<CompilationUnitSyntax> Modify_Typed<TNode>(this CompilationUnitSyntax compilationUnit,
            SyntaxNodeSyntaxAnnotation<TNode> annotation,
            Func<TNode, Task<TNode>> nodeModificationAction)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = await nodeModificationAction(node);

            var outputCompilationUnit = compilationUnit.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        public static CompilationUnitSyntax ModifySynchronous_Typed<TNode>(this CompilationUnitSyntax compilationUnit,
            SyntaxNodeSyntaxAnnotation<TNode> annotation,
            Func<TNode, TNode> nodeModificationAction)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = nodeModificationAction(node);

            var outputCompilationUnit = compilationUnit.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        //public static Task Modify<TDescendantNode>(this CompilationUnitSyntax compilationUnit,
        //    Func<CompilationUnitSyntax, Task<TDescendantNode>> descendantSelector,
        //    Func<CompilationUnitSyntax, SyntaxNodeSyntaxAnnotation<TDescendantNode>, CompilationUnitSyntax> compilationUnitNodeModifierAction)
        //    where TDescendantNode : SyntaxNode
        //{

        //}

        //public static Task Modify<TNode, TDescendantNode>(this CompilationUnitSyntax compilationUnit,
        //    TNode node,
        //    Func<TNode, Task<TDescendantNode>> descendantSelector,
        //    Func<CompilationUnitSyntax, SyntaxNodeSyntaxAnnotation<TDescendantNode>, CompilationUnitSyntax> compilationUnitNodeModifierAction)
        //    where TDescendantNode : SyntaxNode
        //{

        //}
    }
}