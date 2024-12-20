﻿using Microsoft.CodeAnalysis;
using System.Linq;

namespace Generators.Shared.Builder;

internal class NamespaceBuilder : TypeBuilder<NamespaceBuilder>
{
    public NamespaceBuilder() { }
    public override NodeType Type => NodeType.NameSpace;
    public string? Namespace { get; set; }
    public bool IsFileScoped { get; set; }
    public override int Level => IsFileScoped ? -1 : 0;
    public override string ToString()
    {
        if (IsFileScoped)
        {
            return
$$"""
namespace {{Namespace}};

{{string.Join("\t", Members)}}

""";
        }
        else
        {
            return
$$"""
namespace {{Namespace}}
{
{{string.Join("\t", Members)}}
}
""";
        }
    }
}
