using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0126;


namespace System
{
    public static class ISyntaxNodeAnnotationExtensions
    {
        // No Annotate() for the syntax node annotation, since if we have an annotation for a node, it is assumed we don't need to get another annotation for the node.

        //// No need, since we will need a root node instance to annotate a specified child node of a child specified with an annotation. Just annotate the child directly!
        //public static TRootNode AnnotateNode<TRootNode, TNode>(this SyntaxNodeSyntaxAnnotation<TRootNode> rootNode,
        //    TNode node,
        //    out SyntaxNodeSyntaxAnnotation<TNode> annotation)
        //    where TRootNode : SyntaxNode
        //    where TNode : SyntaxNode
        //{
        //    var rootNode = 

        //    var output = rootNode.AnnotateNode(
        //        node,
        //        out SyntaxAnnotation untypedAnnotation);

        //    annotation = SyntaxNodeSyntaxAnnotation<TNode>.From(untypedAnnotation);

        //    return output;
        //}

        public static NamespaceDeclarationSyntax GetContainingNamespace<TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            CompilationUnitSyntax compilationUnit)
            where TNode : SyntaxNode
        {
            var output = annotation.Get(
                compilationUnit,
                @interface => @interface.GetContainingNamespace());

            return output;
        }

        public static CompilationUnitSyntax GetContainingNamespaceAnnotation<TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            CompilationUnitSyntax compilationUnit,
            out ISyntaxNodeAnnotation<NamespaceDeclarationSyntax> namespaceAnnotation)
            where TNode : SyntaxNode
        {
            var @namespace = annotation.GetContainingNamespace(compilationUnit);

            compilationUnit = compilationUnit.AnnotateNode_Typed(
                @namespace,
                out namespaceAnnotation);

            return compilationUnit;
        }

        public static TOut Get<TNode, TOut>(this ISyntaxNodeAnnotation<TNode> annotation,
            CompilationUnitSyntax compilationUnit,
            Func<TNode, TOut> selector)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var output = selector(node);
            return output;
        }

        public static TOut Get<TRootNode, TNode, TOut>(this ISyntaxNodeAnnotation<TNode> annotation,
            TRootNode rootNode,
            Func<TNode, TOut> selector)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var output = selector(node);
            return output;
        }

        public static TNode GetAnnotatedNode_Typed<TRootNode, TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            TRootNode rootNode)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode(annotation.SyntaxAnnotation) as TNode;
            return node;
        }

        public static async Task<CompilationUnitSyntax> Modify<TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            CompilationUnitSyntax compilationUnit,
            Func<TNode, Task<TNode>> nodeModificationAction)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = await nodeModificationAction(node);

            var outputCompilationUnit = compilationUnit.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        public static CompilationUnitSyntax ModifySynchronous<TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            CompilationUnitSyntax compilationUnit,
            Func<TNode, TNode> nodeModificationAction)
            where TNode : SyntaxNode
        {
            var node = compilationUnit.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = nodeModificationAction(node);

            var outputCompilationUnit = compilationUnit.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        public static async Task<TRootNode> Modify<TRootNode, TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            TRootNode rootNode,
            Func<TNode, Task<TNode>> nodeModificationAction)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = await nodeModificationAction(node);

            var outputCompilationUnit = rootNode.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        public static TRootNode ModifySynchronous<TRootNode, TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            TRootNode rootNode,
            Func<TNode, TNode> nodeModificationAction)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = nodeModificationAction(node);

            var outputCompilationUnit = rootNode.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }
    }
}
