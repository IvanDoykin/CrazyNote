#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000005 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000006 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x00000007 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x00000008 TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000009 System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000A TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000B TSource System.Linq.Enumerable::FirstOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000000C TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000000E System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000010 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000012 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000013 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000014 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000015 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000016 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x00000017 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x00000018 System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x00000019 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000001A System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x0000001B System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000001C System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x0000001D System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000001E System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x0000001F System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000020 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000021 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000022 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000023 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000024 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x00000025 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000026 System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000027 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x00000028 System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x00000029 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002A System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x0000002B System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x0000002C System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000002D System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x0000002E System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x0000002F System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000030 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000031 System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x00000032 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x00000033 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x00000034 System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x00000035 TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x00000036 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x00000037 System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000038 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000039 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x0000003A System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x0000003B System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x0000003C System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x0000003D System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x0000003E System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x0000003F System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000040 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x00000041 System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x00000042 System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x00000043 TElement[] System.Linq.Buffer`1::ToArray()
// 0x00000044 System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x00000045 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x00000046 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000047 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000048 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000049 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x0000004A System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x0000004B System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x0000004C System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x0000004D System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x0000004E System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x0000004F System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000050 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000051 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000052 System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x00000053 System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x00000054 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x00000055 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x00000056 System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x00000057 System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000058 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000059 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x0000005A System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x0000005B System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x0000005C System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x0000005D System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x0000005E T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x0000005F System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000060 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[96] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[96] = 
{
	2945,
	3114,
	3114,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[29] = 
{
	{ 0x02000004, { 50, 4 } },
	{ 0x02000005, { 54, 9 } },
	{ 0x02000006, { 63, 7 } },
	{ 0x02000007, { 70, 10 } },
	{ 0x02000008, { 80, 1 } },
	{ 0x0200000A, { 81, 3 } },
	{ 0x0200000B, { 86, 5 } },
	{ 0x0200000C, { 91, 7 } },
	{ 0x0200000D, { 98, 3 } },
	{ 0x0200000E, { 101, 7 } },
	{ 0x0200000F, { 108, 4 } },
	{ 0x02000010, { 112, 21 } },
	{ 0x02000012, { 133, 2 } },
	{ 0x06000004, { 0, 10 } },
	{ 0x06000005, { 10, 5 } },
	{ 0x06000006, { 15, 2 } },
	{ 0x06000007, { 17, 1 } },
	{ 0x06000008, { 18, 3 } },
	{ 0x06000009, { 21, 2 } },
	{ 0x0600000A, { 23, 4 } },
	{ 0x0600000B, { 27, 3 } },
	{ 0x0600000C, { 30, 4 } },
	{ 0x0600000D, { 34, 3 } },
	{ 0x0600000E, { 37, 1 } },
	{ 0x0600000F, { 38, 3 } },
	{ 0x06000010, { 41, 2 } },
	{ 0x06000011, { 43, 2 } },
	{ 0x06000012, { 45, 5 } },
	{ 0x06000030, { 84, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[135] = 
{
	{ (Il2CppRGCTXDataType)2, 1348 },
	{ (Il2CppRGCTXDataType)3, 6626 },
	{ (Il2CppRGCTXDataType)2, 2347 },
	{ (Il2CppRGCTXDataType)2, 1969 },
	{ (Il2CppRGCTXDataType)3, 11144 },
	{ (Il2CppRGCTXDataType)2, 1434 },
	{ (Il2CppRGCTXDataType)2, 1973 },
	{ (Il2CppRGCTXDataType)3, 11157 },
	{ (Il2CppRGCTXDataType)2, 1971 },
	{ (Il2CppRGCTXDataType)3, 11150 },
	{ (Il2CppRGCTXDataType)2, 471 },
	{ (Il2CppRGCTXDataType)3, 19 },
	{ (Il2CppRGCTXDataType)3, 20 },
	{ (Il2CppRGCTXDataType)2, 907 },
	{ (Il2CppRGCTXDataType)3, 5033 },
	{ (Il2CppRGCTXDataType)2, 1713 },
	{ (Il2CppRGCTXDataType)3, 9184 },
	{ (Il2CppRGCTXDataType)3, 5648 },
	{ (Il2CppRGCTXDataType)2, 565 },
	{ (Il2CppRGCTXDataType)3, 597 },
	{ (Il2CppRGCTXDataType)3, 598 },
	{ (Il2CppRGCTXDataType)2, 1435 },
	{ (Il2CppRGCTXDataType)3, 7097 },
	{ (Il2CppRGCTXDataType)2, 1280 },
	{ (Il2CppRGCTXDataType)2, 984 },
	{ (Il2CppRGCTXDataType)2, 1074 },
	{ (Il2CppRGCTXDataType)2, 1130 },
	{ (Il2CppRGCTXDataType)2, 1075 },
	{ (Il2CppRGCTXDataType)2, 1131 },
	{ (Il2CppRGCTXDataType)3, 5034 },
	{ (Il2CppRGCTXDataType)2, 1281 },
	{ (Il2CppRGCTXDataType)2, 985 },
	{ (Il2CppRGCTXDataType)2, 1076 },
	{ (Il2CppRGCTXDataType)2, 1132 },
	{ (Il2CppRGCTXDataType)2, 1077 },
	{ (Il2CppRGCTXDataType)2, 1133 },
	{ (Il2CppRGCTXDataType)3, 5035 },
	{ (Il2CppRGCTXDataType)2, 1067 },
	{ (Il2CppRGCTXDataType)2, 1068 },
	{ (Il2CppRGCTXDataType)2, 1128 },
	{ (Il2CppRGCTXDataType)3, 5032 },
	{ (Il2CppRGCTXDataType)2, 983 },
	{ (Il2CppRGCTXDataType)2, 1073 },
	{ (Il2CppRGCTXDataType)2, 982 },
	{ (Il2CppRGCTXDataType)3, 12809 },
	{ (Il2CppRGCTXDataType)3, 4646 },
	{ (Il2CppRGCTXDataType)2, 817 },
	{ (Il2CppRGCTXDataType)2, 1070 },
	{ (Il2CppRGCTXDataType)2, 1129 },
	{ (Il2CppRGCTXDataType)2, 1183 },
	{ (Il2CppRGCTXDataType)3, 6627 },
	{ (Il2CppRGCTXDataType)3, 6629 },
	{ (Il2CppRGCTXDataType)2, 344 },
	{ (Il2CppRGCTXDataType)3, 6628 },
	{ (Il2CppRGCTXDataType)3, 6637 },
	{ (Il2CppRGCTXDataType)2, 1351 },
	{ (Il2CppRGCTXDataType)2, 1972 },
	{ (Il2CppRGCTXDataType)3, 11151 },
	{ (Il2CppRGCTXDataType)3, 6638 },
	{ (Il2CppRGCTXDataType)2, 1101 },
	{ (Il2CppRGCTXDataType)2, 1151 },
	{ (Il2CppRGCTXDataType)3, 5040 },
	{ (Il2CppRGCTXDataType)3, 12804 },
	{ (Il2CppRGCTXDataType)3, 6630 },
	{ (Il2CppRGCTXDataType)2, 1350 },
	{ (Il2CppRGCTXDataType)2, 1970 },
	{ (Il2CppRGCTXDataType)3, 11145 },
	{ (Il2CppRGCTXDataType)3, 5039 },
	{ (Il2CppRGCTXDataType)3, 6631 },
	{ (Il2CppRGCTXDataType)3, 12803 },
	{ (Il2CppRGCTXDataType)3, 6644 },
	{ (Il2CppRGCTXDataType)2, 1352 },
	{ (Il2CppRGCTXDataType)2, 1974 },
	{ (Il2CppRGCTXDataType)3, 11158 },
	{ (Il2CppRGCTXDataType)3, 7138 },
	{ (Il2CppRGCTXDataType)3, 4047 },
	{ (Il2CppRGCTXDataType)3, 5041 },
	{ (Il2CppRGCTXDataType)3, 4046 },
	{ (Il2CppRGCTXDataType)3, 6645 },
	{ (Il2CppRGCTXDataType)3, 12805 },
	{ (Il2CppRGCTXDataType)3, 5038 },
	{ (Il2CppRGCTXDataType)2, 474 },
	{ (Il2CppRGCTXDataType)3, 28 },
	{ (Il2CppRGCTXDataType)3, 9171 },
	{ (Il2CppRGCTXDataType)2, 1714 },
	{ (Il2CppRGCTXDataType)3, 9185 },
	{ (Il2CppRGCTXDataType)2, 566 },
	{ (Il2CppRGCTXDataType)3, 599 },
	{ (Il2CppRGCTXDataType)3, 9177 },
	{ (Il2CppRGCTXDataType)3, 4026 },
	{ (Il2CppRGCTXDataType)2, 360 },
	{ (Il2CppRGCTXDataType)3, 9172 },
	{ (Il2CppRGCTXDataType)2, 1710 },
	{ (Il2CppRGCTXDataType)3, 1003 },
	{ (Il2CppRGCTXDataType)2, 583 },
	{ (Il2CppRGCTXDataType)2, 804 },
	{ (Il2CppRGCTXDataType)3, 4032 },
	{ (Il2CppRGCTXDataType)3, 9173 },
	{ (Il2CppRGCTXDataType)3, 4021 },
	{ (Il2CppRGCTXDataType)3, 4022 },
	{ (Il2CppRGCTXDataType)3, 4020 },
	{ (Il2CppRGCTXDataType)3, 4023 },
	{ (Il2CppRGCTXDataType)2, 800 },
	{ (Il2CppRGCTXDataType)2, 2413 },
	{ (Il2CppRGCTXDataType)3, 5037 },
	{ (Il2CppRGCTXDataType)3, 4025 },
	{ (Il2CppRGCTXDataType)2, 1051 },
	{ (Il2CppRGCTXDataType)3, 4024 },
	{ (Il2CppRGCTXDataType)2, 986 },
	{ (Il2CppRGCTXDataType)2, 2376 },
	{ (Il2CppRGCTXDataType)2, 1080 },
	{ (Il2CppRGCTXDataType)2, 1134 },
	{ (Il2CppRGCTXDataType)3, 4665 },
	{ (Il2CppRGCTXDataType)2, 826 },
	{ (Il2CppRGCTXDataType)3, 5527 },
	{ (Il2CppRGCTXDataType)3, 5528 },
	{ (Il2CppRGCTXDataType)3, 5533 },
	{ (Il2CppRGCTXDataType)2, 1191 },
	{ (Il2CppRGCTXDataType)3, 5530 },
	{ (Il2CppRGCTXDataType)3, 13083 },
	{ (Il2CppRGCTXDataType)2, 805 },
	{ (Il2CppRGCTXDataType)3, 4041 },
	{ (Il2CppRGCTXDataType)1, 1048 },
	{ (Il2CppRGCTXDataType)2, 2384 },
	{ (Il2CppRGCTXDataType)3, 5529 },
	{ (Il2CppRGCTXDataType)1, 2384 },
	{ (Il2CppRGCTXDataType)1, 1191 },
	{ (Il2CppRGCTXDataType)2, 2430 },
	{ (Il2CppRGCTXDataType)2, 2384 },
	{ (Il2CppRGCTXDataType)3, 5534 },
	{ (Il2CppRGCTXDataType)3, 5532 },
	{ (Il2CppRGCTXDataType)3, 5531 },
	{ (Il2CppRGCTXDataType)2, 244 },
	{ (Il2CppRGCTXDataType)3, 4048 },
	{ (Il2CppRGCTXDataType)2, 350 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	96,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	29,
	s_rgctxIndices,
	135,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
