#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// AssemblyCSharp.Line
struct Line_t836643024;

#include "codegen/il2cpp-codegen.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "AssemblyU2DCSharp_AssemblyCSharp_Line836643024.h"

// System.Void AssemblyCSharp.Line::.ctor(UnityEngine.Vector2,UnityEngine.Vector2)
extern "C"  void Line__ctor_m3904780414 (Line_t836643024 * __this, Vector2_t2243707579  ___pkt10, Vector2_t2243707579  ___pkt21, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Single AssemblyCSharp.Line::GetY(System.Single)
extern "C"  float Line_GetY_m597998668 (Line_t836643024 * __this, float ___x0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Single AssemblyCSharp.Line::S()
extern "C"  float Line_S_m2917280219 (Line_t836643024 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Single AssemblyCSharp.Line::M()
extern "C"  float Line_M_m3958861777 (Line_t836643024 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector2 AssemblyCSharp.Line::Intersect(AssemblyCSharp.Line)
extern "C"  Vector2_t2243707579  Line_Intersect_m2987124297 (Line_t836643024 * __this, Line_t836643024 * ___other0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean AssemblyCSharp.Line::hasIntersection(AssemblyCSharp.Line)
extern "C"  bool Line_hasIntersection_m3594207284 (Line_t836643024 * __this, Line_t836643024 * ___other0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
