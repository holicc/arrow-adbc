// Code generated by _tmpl/driver.go.tmpl. DO NOT EDIT.

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

//go:build driverlib

package main

// #include "../../drivermgr/adbc.h"
// #include "utils.h"
// #include <stdint.h>
// #include <string.h>
//
// typedef const char cchar_t;
// typedef const uint8_t cuint8_t;
//
// void releasePartitions(struct AdbcPartitions* partitions);
//
import "C"
import (
	"context"
	"errors"
	"fmt"
	"runtime/cgo"
	"unsafe"

	"github.com/apache/arrow-adbc/go/adbc"
	"github.com/apache/arrow-adbc/go/adbc/driver/flightsql"
	"github.com/apache/arrow/go/v10/arrow/array"
	"github.com/apache/arrow/go/v10/arrow/cdata"
)

var drv = flightsql.Driver{}

const errPrefix = "[FlightSQL] "

func setErr(err *C.struct_AdbcError, format string, vals ...interface{}) {
	if err == nil {
		return
	}

	if err.release != nil {
		C.FlightSQLerrRelease(err)
	}

	msg := errPrefix + fmt.Sprintf(format, vals...)
	err.message = C.CString(msg)
	err.release = (*[0]byte)(C.FlightSQL_release_error)
}

func errToAdbcErr(adbcerr *C.struct_AdbcError, err error) adbc.Status {
	if adbcerr == nil || err == nil {
		return adbc.StatusOK
	}

	var adbcError adbc.Error
	if errors.As(err, &adbcError) {
		setErr(adbcerr, adbcError.Msg)
		return adbcError.Code
	}

	setErr(adbcerr, err.Error())
	return adbc.StatusUnknown
}

func getFromHandle[T any](ptr unsafe.Pointer) *T {
	return (*(*cgo.Handle)(ptr)).Value().(*T)
}

func checkDBAlloc(db *C.struct_AdbcDatabase, err *C.struct_AdbcError, fname string) bool {
	if db.private_data == nil {
		setErr(err, "%s: database not allocated", fname)
		return false
	}
	return true
}

func checkDBInit(db *C.struct_AdbcDatabase, err *C.struct_AdbcError, fname string) *cDatabase {
	if !checkDBAlloc(db, err, fname) {
		return nil
	}
	cdb := getFromHandle[cDatabase](db.private_data)
	if cdb.db == nil {
		setErr(err, "%s: database not initialized", fname)
		return nil
	}

	return cdb
}

type cDatabase struct {
	opts map[string]string
	db   adbc.Database
}

//export FlightSQLDatabaseNew
func FlightSQLDatabaseNew(db *C.struct_AdbcDatabase, err *C.struct_AdbcError) C.AdbcStatusCode {
	if db.private_data != nil {
		setErr(err, "AdbcDatabaseNew: database already allocated")
		return C.ADBC_STATUS_INVALID_STATE
	}
	dbobj := &cDatabase{opts: make(map[string]string)}
	hndl := cgo.NewHandle(dbobj)
	db.private_data = unsafe.Pointer(&hndl)
	return C.ADBC_STATUS_OK
}

//export FlightSQLDatabaseSetOption
func FlightSQLDatabaseSetOption(db *C.struct_AdbcDatabase, key, value *C.cchar_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkDBAlloc(db, err, "AdbcDatabaseSetOption") {
		return C.ADBC_STATUS_INVALID_STATE
	}
	cdb := getFromHandle[cDatabase](db.private_data)

	k, v := C.GoString(key), C.GoString(value)
	cdb.opts[k] = v

	return C.ADBC_STATUS_OK
}

//export FlightSQLDatabaseInit
func FlightSQLDatabaseInit(db *C.struct_AdbcDatabase, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkDBAlloc(db, err, "AdbcDatabaseInit") {
		return C.ADBC_STATUS_INVALID_STATE
	}
	cdb := getFromHandle[cDatabase](db.private_data)

	if cdb.db != nil {
		setErr(err, "AdbcDatabaseInit: database already initialized")
		return C.ADBC_STATUS_INVALID_STATE
	}

	adb, aerr := drv.NewDatabase(cdb.opts)
	if aerr != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, aerr))
	}

	cdb.db = adb
	return C.ADBC_STATUS_OK
}

//export FlightSQLDatabaseRelease
func FlightSQLDatabaseRelease(db *C.struct_AdbcDatabase, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkDBAlloc(db, err, "AdbcDatabaseInit") {
		return C.ADBC_STATUS_INVALID_STATE
	}
	h := (*(*cgo.Handle)(db.private_data))

	cdb := h.Value().(*cDatabase)
	if cdb.db == nil {
		setErr(err, "AdbcDatabaseRelease: attempting to release uninitialized database")
		return C.ADBC_STATUS_INVALID_STATE
	}
	cdb.db = nil
	cdb.opts = nil
	db.private_data = nil
	h.Delete()
	return C.ADBC_STATUS_OK
}

type cConn struct {
	cnxn adbc.Connection
}

func checkConnAlloc(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError, fname string) bool {
	if cnxn.private_data == nil {
		setErr(err, "%s: connection not allocated", fname)
		return false
	}
	return true
}

func checkConnInit(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError, fname string) *cConn {
	if !checkConnAlloc(cnxn, err, fname) {
		return nil
	}
	conn := getFromHandle[cConn](cnxn.private_data)
	if conn.cnxn == nil {
		setErr(err, "%s: connection not initialized", fname)
		return nil
	}

	return conn
}

//export FlightSQLConnectionNew
func FlightSQLConnectionNew(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError) C.AdbcStatusCode {
	if cnxn.private_data != nil {
		setErr(err, "AdbcConnectionNew: connection already allocated")
		return C.ADBC_STATUS_INVALID_STATE
	}

	hndl := cgo.NewHandle(&cConn{})
	cnxn.private_data = unsafe.Pointer(&hndl)
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionSetOption
func FlightSQLConnectionSetOption(cnxn *C.struct_AdbcConnection, key, val *C.cchar_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkConnAlloc(cnxn, err, "AdbcConnectionSetOption") {
		return C.ADBC_STATUS_INVALID_STATE
	}
	conn := getFromHandle[cConn](cnxn.private_data)

	code := errToAdbcErr(err, conn.cnxn.(adbc.PostInitOptions).SetOption(C.GoString(key), C.GoString(val)))
	return C.AdbcStatusCode(code)
}

//export FlightSQLConnectionInit
func FlightSQLConnectionInit(cnxn *C.struct_AdbcConnection, db *C.struct_AdbcDatabase, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkConnAlloc(cnxn, err, "AdbcConnectionInit") {
		return C.ADBC_STATUS_INVALID_STATE
	}

	conn := getFromHandle[cConn](cnxn.private_data)
	if conn.cnxn != nil {
		setErr(err, "AdbcConnectionInit: connection already initialized")
		return C.ADBC_STATUS_INVALID_STATE
	}
	cdb := checkDBInit(db, err, "AdbcConnectionInit")
	if cdb == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}
	c, e := cdb.db.Open(context.Background())
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	conn.cnxn = c
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionRelease
func FlightSQLConnectionRelease(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError) C.AdbcStatusCode {
	if !checkConnAlloc(cnxn, err, "AdbcConnectionRelease") {
		return C.ADBC_STATUS_INVALID_STATE
	}
	h := (*(*cgo.Handle)(cnxn.private_data))

	conn := h.Value().(*cConn)
	if conn.cnxn == nil {
		setErr(err, "AdbcConnectionRelease: attempting to release uninitialized connection")
		return C.ADBC_STATUS_INVALID_STATE
	}
	defer func() {
		conn.cnxn = nil
		cnxn.private_data = nil
		h.Delete()
	}()
	return C.AdbcStatusCode(errToAdbcErr(err, conn.cnxn.Close()))
}

func fromCArr[T, CType any](ptr *CType, sz int) []T {
	if ptr == nil || sz == 0 {
		return nil
	}

	return unsafe.Slice((*T)(unsafe.Pointer(ptr)), sz)
}

func toCdataStream(ptr *C.struct_ArrowArrayStream) *cdata.CArrowArrayStream {
	return (*cdata.CArrowArrayStream)(unsafe.Pointer(ptr))
}

func toCdataSchema(ptr *C.struct_ArrowSchema) *cdata.CArrowSchema {
	return (*cdata.CArrowSchema)(unsafe.Pointer(ptr))
}

func toCdataArray(ptr *C.struct_ArrowArray) *cdata.CArrowArray {
	return (*cdata.CArrowArray)(unsafe.Pointer(ptr))
}

//export FlightSQLConnectionGetInfo
func FlightSQLConnectionGetInfo(cnxn *C.struct_AdbcConnection, codes *C.uint32_t, len C.size_t, out *C.struct_ArrowArrayStream, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionGetInfo")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	infoCodes := fromCArr[adbc.InfoCode](codes, int(len))
	rdr, e := conn.cnxn.GetInfo(context.Background(), infoCodes)
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	cdata.ExportRecordReader(rdr, toCdataStream(out))
	return C.ADBC_STATUS_OK
}

func toStrPtr(in *C.cchar_t) *string {
	if in == nil {
		return nil
	}

	out := C.GoString((*C.char)(in))
	return &out
}

func toStrSlice(in **C.cchar_t) []string {
	if in == nil {
		return nil
	}

	sz := unsafe.Sizeof(*in)

	out := make([]string, 0, 1)
	for *in != nil {
		out = append(out, C.GoString(*in))
		in = (**C.cchar_t)(unsafe.Add(unsafe.Pointer(in), sz))
	}
	return out
}

//export FlightSQLConnectionGetObjects
func FlightSQLConnectionGetObjects(cnxn *C.struct_AdbcConnection, depth C.int, catalog, dbSchema, tableName *C.cchar_t, tableType **C.cchar_t, columnName *C.cchar_t,
	out *C.struct_ArrowArrayStream, err *C.struct_AdbcError) C.AdbcStatusCode {

	conn := checkConnInit(cnxn, err, "AdbcConnectionGetObjects")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rdr, e := conn.cnxn.GetObjects(context.Background(), adbc.ObjectDepth(depth), toStrPtr(catalog), toStrPtr(dbSchema), toStrPtr(tableName), toStrPtr(columnName), toStrSlice(tableType))
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}
	cdata.ExportRecordReader(rdr, toCdataStream(out))
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionGetTableSchema
func FlightSQLConnectionGetTableSchema(cnxn *C.struct_AdbcConnection, catalog, dbSchema, tableName *C.cchar_t, schema *C.struct_ArrowSchema, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionGetTableSchema")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	sc, e := conn.cnxn.GetTableSchema(context.Background(), toStrPtr(catalog), toStrPtr(dbSchema), C.GoString(tableName))
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}
	cdata.ExportArrowSchema(sc, toCdataSchema(schema))
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionGetTableTypes
func FlightSQLConnectionGetTableTypes(cnxn *C.struct_AdbcConnection, out *C.struct_ArrowArrayStream, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionGetTableTypes")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rdr, e := conn.cnxn.GetTableTypes(context.Background())
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}
	cdata.ExportRecordReader(rdr, toCdataStream(out))
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionReadPartition
func FlightSQLConnectionReadPartition(cnxn *C.struct_AdbcConnection, serialized *C.cuint8_t, serializedLen C.size_t, out *C.struct_ArrowArrayStream, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionReadPartition")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rdr, e := conn.cnxn.ReadPartition(context.Background(), fromCArr[byte](serialized, int(serializedLen)))
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}
	cdata.ExportRecordReader(rdr, toCdataStream(out))
	return C.ADBC_STATUS_OK
}

//export FlightSQLConnectionCommit
func FlightSQLConnectionCommit(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionCommit")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, conn.cnxn.Commit(context.Background())))
}

//export FlightSQLConnectionRollback
func FlightSQLConnectionRollback(cnxn *C.struct_AdbcConnection, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcConnectionRollback")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, conn.cnxn.Rollback(context.Background())))
}

func checkStmtInit(stmt *C.struct_AdbcStatement, err *C.struct_AdbcError, fname string) adbc.Statement {
	if stmt == nil {
		setErr(err, "%s: statement not allocated", fname)
		return nil
	}

	if stmt.private_data == nil {
		setErr(err, "%s: statement not initialized", fname)
		return nil
	}

	return (*(*cgo.Handle)(stmt.private_data)).Value().(adbc.Statement)
}

//export FlightSQLStatementNew
func FlightSQLStatementNew(cnxn *C.struct_AdbcConnection, stmt *C.struct_AdbcStatement, err *C.struct_AdbcError) C.AdbcStatusCode {
	conn := checkConnInit(cnxn, err, "AdbcStatementNew")
	if conn == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	st, e := conn.cnxn.NewStatement()
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	h := cgo.NewHandle(st)
	stmt.private_data = unsafe.Pointer(&h)
	return C.ADBC_STATUS_OK
}

//export FlightSQLStatementRelease
func FlightSQLStatementRelease(stmt *C.struct_AdbcStatement, err *C.struct_AdbcError) C.AdbcStatusCode {
	if stmt == nil {
		setErr(err, "AdbcStatementRelease: statement not allocated")
		return C.ADBC_STATUS_INVALID_STATE
	}

	if stmt.private_data == nil {
		setErr(err, "AdbcStatementRelease: statement not initialized")
		return C.ADBC_STATUS_INVALID_STATE
	}

	h := (*(*cgo.Handle)(stmt.private_data))
	st := h.Value().(adbc.Statement)
	stmt.private_data = nil

	e := st.Close()
	h.Delete()
	return C.AdbcStatusCode(errToAdbcErr(err, e))
}

//export FlightSQLStatementPrepare
func FlightSQLStatementPrepare(stmt *C.struct_AdbcStatement, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementPrepare")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, st.Prepare(context.Background())))
}

//export FlightSQLStatementExecuteQuery
func FlightSQLStatementExecuteQuery(stmt *C.struct_AdbcStatement, out *C.struct_ArrowArrayStream, affected *C.int64_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementExecuteQuery")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rdr, n, e := st.ExecuteQuery(context.Background())
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	if affected != nil {
		*affected = C.int64_t(n)
	}

	cdata.ExportRecordReader(rdr, toCdataStream(out))
	return C.ADBC_STATUS_OK
}

//export FlightSQLStatementSetSqlQuery
func FlightSQLStatementSetSqlQuery(stmt *C.struct_AdbcStatement, query *C.cchar_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementSetSqlQuery")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, st.SetSqlQuery(C.GoString(query))))
}

//export FlightSQLStatementSetSubstraitPlan
func FlightSQLStatementSetSubstraitPlan(stmt *C.struct_AdbcStatement, plan *C.cuint8_t, length C.size_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementSetSubstraitPlan")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, st.SetSubstraitPlan(fromCArr[byte](plan, int(length)))))
}

//export FlightSQLStatementBind
func FlightSQLStatementBind(stmt *C.struct_AdbcStatement, values *C.struct_ArrowArray, schema *C.struct_ArrowSchema, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementBind")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rec, e := cdata.ImportCRecordBatch(toCdataArray(values), toCdataSchema(schema))
	if e != nil {
		// if there was an error, we need to manually release the input
		cdata.ReleaseCArrowArray(toCdataArray(values))
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}
	defer rec.Release()

	return C.AdbcStatusCode(errToAdbcErr(err, st.Bind(context.Background(), rec)))
}

//export FlightSQLStatementBindStream
func FlightSQLStatementBindStream(stmt *C.struct_AdbcStatement, stream *C.struct_ArrowArrayStream, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementBindStream")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	rdr := cdata.ImportCArrayStream(toCdataStream(stream), nil)
	return C.AdbcStatusCode(errToAdbcErr(err, st.BindStream(context.Background(), rdr.(array.RecordReader))))
}

//export FlightSQLStatementGetParameterSchema
func FlightSQLStatementGetParameterSchema(stmt *C.struct_AdbcStatement, schema *C.struct_ArrowSchema, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementGetParameterSchema")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	sc, e := st.GetParameterSchema()
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	cdata.ExportArrowSchema(sc, toCdataSchema(schema))
	return C.ADBC_STATUS_OK
}

//export FlightSQLStatementSetOption
func FlightSQLStatementSetOption(stmt *C.struct_AdbcStatement, key, value *C.cchar_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementSetOption")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	return C.AdbcStatusCode(errToAdbcErr(err, st.SetOption(C.GoString(key), C.GoString(value))))
}

//export releasePartitions
func releasePartitions(partitions *C.struct_AdbcPartitions) {
	C.free(unsafe.Pointer(partitions.partitions))
	C.free(unsafe.Pointer(partitions.partition_lengths))
	h := (*(*cgo.Handle)(partitions.private_data))
	h.Delete()
}

//export FlightSQLStatementExecutePartitions
func FlightSQLStatementExecutePartitions(stmt *C.struct_AdbcStatement, schema *C.struct_ArrowSchema, partitions *C.struct_AdbcPartitions, affected *C.int64_t, err *C.struct_AdbcError) C.AdbcStatusCode {
	st := checkStmtInit(stmt, err, "AdbcStatementExecutePartitions")
	if st == nil {
		return C.ADBC_STATUS_INVALID_STATE
	}

	sc, part, n, e := st.ExecutePartitions(context.Background())
	if e != nil {
		return C.AdbcStatusCode(errToAdbcErr(err, e))
	}

	if partitions == nil {
		setErr(err, "AdbcStatementExecutePartitions: partitions output struct is null")
		return C.ADBC_STATUS_INVALID_ARGUMENT
	}

	if affected != nil {
		*affected = C.int64_t(n)
	}

	if sc != nil && schema != nil {
		cdata.ExportArrowSchema(sc, toCdataSchema(schema))
	}

	partitions.num_partitions = C.size_t(part.NumPartitions)
	partitions.partitions = (**C.cuint8_t)(C.malloc(C.size_t(unsafe.Sizeof((*C.uint8_t)(nil)) * uintptr(part.NumPartitions))))
	partitions.partition_lengths = (*C.size_t)(C.malloc(C.size_t(unsafe.Sizeof(C.size_t(0)) * uintptr(part.NumPartitions))))

	partIDs := fromCArr[*C.cuint8_t](partitions.partitions, int(partitions.num_partitions))
	partLens := fromCArr[C.size_t](partitions.partition_lengths, int(partitions.num_partitions))
	for i, p := range part.PartitionIDs {
		partIDs[i] = (*C.cuint8_t)(unsafe.Pointer(&p[0]))
		partLens[i] = C.size_t(len(p))
	}

	h := cgo.NewHandle(part)
	partitions.private_data = unsafe.Pointer(&h)
	partitions.release = (*[0]byte)(C.releasePartitions)
	return C.ADBC_STATUS_OK
}

//export FlightSQLDriverInit
func FlightSQLDriverInit(version C.int, rawDriver *C.void, err *C.struct_AdbcError) C.AdbcStatusCode {
	if version != C.ADBC_VERSION_1_0_0 {
		setErr(err, "Only version %d supported, got %d", int(C.ADBC_VERSION_1_0_0), int(version))
		return C.ADBC_STATUS_NOT_IMPLEMENTED
	}

	driver := (*C.struct_AdbcDriver)(unsafe.Pointer(rawDriver))
	C.memset(unsafe.Pointer(driver), 0, C.sizeof_struct_AdbcDriver)
	driver.DatabaseInit = (*[0]byte)(C.FlightSQLDatabaseInit)
	driver.DatabaseNew = (*[0]byte)(C.FlightSQLDatabaseNew)
	driver.DatabaseRelease = (*[0]byte)(C.FlightSQLDatabaseRelease)
	driver.DatabaseSetOption = (*[0]byte)(C.FlightSQLDatabaseSetOption)

	driver.ConnectionNew = (*[0]byte)(C.FlightSQLConnectionNew)
	driver.ConnectionInit = (*[0]byte)(C.FlightSQLConnectionInit)
	driver.ConnectionRelease = (*[0]byte)(C.FlightSQLConnectionRelease)
	driver.ConnectionSetOption = (*[0]byte)(C.FlightSQLConnectionSetOption)
	driver.ConnectionGetInfo = (*[0]byte)(C.FlightSQLConnectionGetInfo)
	driver.ConnectionGetObjects = (*[0]byte)(C.FlightSQLConnectionGetObjects)
	driver.ConnectionGetTableSchema = (*[0]byte)(C.FlightSQLConnectionGetTableSchema)
	driver.ConnectionGetTableTypes = (*[0]byte)(C.FlightSQLConnectionGetTableTypes)
	driver.ConnectionReadPartition = (*[0]byte)(C.FlightSQLConnectionReadPartition)
	driver.ConnectionCommit = (*[0]byte)(C.FlightSQLConnectionCommit)
	driver.ConnectionRollback = (*[0]byte)(C.FlightSQLConnectionRollback)

	driver.StatementNew = (*[0]byte)(C.FlightSQLStatementNew)
	driver.StatementRelease = (*[0]byte)(C.FlightSQLStatementRelease)
	driver.StatementSetOption = (*[0]byte)(C.FlightSQLStatementSetOption)
	driver.StatementSetSqlQuery = (*[0]byte)(C.FlightSQLStatementSetSqlQuery)
	driver.StatementSetSubstraitPlan = (*[0]byte)(C.FlightSQLStatementSetSubstraitPlan)
	driver.StatementBind = (*[0]byte)(C.FlightSQLStatementBind)
	driver.StatementBindStream = (*[0]byte)(C.FlightSQLStatementBindStream)
	driver.StatementExecuteQuery = (*[0]byte)(C.FlightSQLStatementExecuteQuery)
	driver.StatementExecutePartitions = (*[0]byte)(C.FlightSQLStatementExecutePartitions)
	driver.StatementGetParameterSchema = (*[0]byte)(C.FlightSQLStatementGetParameterSchema)

	return C.ADBC_STATUS_OK
}

func main() {}
