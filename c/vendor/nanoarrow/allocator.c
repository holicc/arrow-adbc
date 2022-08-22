// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

#include <stddef.h>
#include <stdlib.h>

#include "nanoarrow.h"

void* ArrowMalloc(int64_t size) { return malloc(size); }

void* ArrowRealloc(void* ptr, int64_t size) { return realloc(ptr, size); }

void ArrowFree(void* ptr) { free(ptr); }

static uint8_t* ArrowBufferAllocatorMallocAllocate(struct ArrowBufferAllocator* allocator,
                                                   int64_t size) {
  return ArrowMalloc(size);
}

static uint8_t* ArrowBufferAllocatorMallocReallocate(
    struct ArrowBufferAllocator* allocator, uint8_t* ptr, int64_t old_size,
    int64_t new_size) {
  return ArrowRealloc(ptr, new_size);
}

static void ArrowBufferAllocatorMallocFree(struct ArrowBufferAllocator* allocator,
                                           uint8_t* ptr, int64_t size) {
  ArrowFree(ptr);
}

static struct ArrowBufferAllocator ArrowBufferAllocatorMalloc = {
    &ArrowBufferAllocatorMallocReallocate, &ArrowBufferAllocatorMallocFree, NULL};

struct ArrowBufferAllocator ArrowBufferAllocatorDefault() {
  return ArrowBufferAllocatorMalloc;
}

static uint8_t* ArrowBufferAllocatorNeverAllocate(struct ArrowBufferAllocator* allocator,
                                                  int64_t size) {
  return NULL;
}

static uint8_t* ArrowBufferAllocatorNeverReallocate(
    struct ArrowBufferAllocator* allocator, uint8_t* ptr, int64_t old_size,
    int64_t new_size) {
  return NULL;
}

struct ArrowBufferAllocator ArrowBufferDeallocator(
    void (*custom_free)(struct ArrowBufferAllocator* allocator, uint8_t* ptr,
                        int64_t size),
    void* private_data) {
  struct ArrowBufferAllocator allocator;
  allocator.reallocate = &ArrowBufferAllocatorNeverReallocate;
  allocator.free = custom_free;
  allocator.private_data = private_data;
  return allocator;
}